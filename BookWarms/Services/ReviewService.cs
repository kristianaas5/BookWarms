using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class ReviewService
    {
        private readonly AppDbContext _context;
        public ReviewService(AppDbContext context) => _context = context;

        // Взимане на всички ревюта
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(r => r.Library).ThenInclude(l => l.User)
                .Include(r => r.Library).ThenInclude(l => l.Book)
                .ToListAsync();
        }

        // Взимане на ревю по Id
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(r => r.Library).ThenInclude(l => l.User)
                .Include(r => r.Library).ThenInclude(l => l.Book)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Добавяне на ревю (само за книги в Read shelf)
        public async Task<Review?> AddReviewAsync(Review review)
        {
            var library = await _context.Libraries
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == review.LibraryId);

            if (library == null) return null;
            if (library.ShelfType != ShelfType.Read) return null;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        // Обновяване на ревю
        public async Task<bool> UpdateReviewAsync(Review review)
        {
            var existing = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);
            if (existing == null) return false;

            existing.ReviewText = review.ReviewText;
            existing.Rating = review.Rating;

            _context.Reviews.Update(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        // Soft Delete
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null || review.IsDeleted) return false;
            review.IsDeleted = true;
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RestoreReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id && r.IsDeleted);
            if (review == null) return false;
            review.IsDeleted = false;
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync() > 0;
        }

        // Взимане на ревюта за конкретен потребител (включва Library -> Book, User)
        public async Task<List<Review>> GetUserReviewsAsync(int userId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(r => r.Library).ThenInclude(l => l.Book)
                .Include(r => r.Library).ThenInclude(l => l.User)
                .Where(r =>
                    r.Library.UserId == userId &&
                    !r.IsDeleted &&
                    r.Library != null && !r.Library.IsDeleted &&
                    r.Library.Book != null && !r.Library.Book.IsDeleted)
                .ToListAsync();
        }

        // Reviews for a specific book (safe against soft-deletes)
        public async Task<List<Review>> GetBookReviewsAsync(int bookId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(r => r.Library).ThenInclude(l => l.User)
                .Include(r => r.Library).ThenInclude(l => l.Book)
                .Where(r =>
                    !r.IsDeleted &&
                    r.Library != null && !r.Library.IsDeleted &&
                    r.Library.Book != null && !r.Library.Book.IsDeleted &&
                    r.Library.BookId == bookId)
                .ToListAsync();
        }

        // Compute per-user yearly stats and top genres from reviews of read books
        public async Task<UserReadingStats> GetUserReadingStatsAsync(int userId)
        {
            var data = await _context.Reviews
                .AsNoTracking()
                .Include(r => r.Library).ThenInclude(l => l.Book)
                .Include(r => r.Library).ThenInclude(l => l.User)
                .Where(r =>
                    !r.IsDeleted &&
                    r.Library != null && !r.Library.IsDeleted &&
                    r.Library.Book != null && !r.Library.Book.IsDeleted &&
                    r.Library.UserId == userId)
                .Select(r => new
                {
                    Year = r.Date.Year,
                    Pages = r.Library!.Book!.PageCount,
                    Genre = r.Library!.Book!.Genre ?? string.Empty,
                    r.LibraryId
                })
                .ToListAsync();

            var yearly = data
                .GroupBy(x => x.Year)
                .Select(g => new YearlyStat
                {
                    Year = g.Key,
                    BooksRead = g.Select(x => x.LibraryId).Distinct().Count(),
                    PagesRead = g.Sum(x => x.Pages)
                })
                .OrderBy(x => x.Year)
                .ToList();

            var topGenres = data
                .Where(x => !string.IsNullOrWhiteSpace(x.Genre))
                .GroupBy(x => x.Genre)
                .Select(g => new GenreStat { Genre = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            return new UserReadingStats
            {
                Yearly = yearly,
                TopGenres = topGenres
            };
        }
    }
}
