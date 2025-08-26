using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class ReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        // Взимане на всички ревюта
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews
                .Include(r => r.Library)
                    .ThenInclude(l => l.User)
                .Include(r => r.Library)
                    .ThenInclude(l => l.Book)
                .ToListAsync();
        }

        // Взимане на ревю по Id
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Library)
                    .ThenInclude(l => l.User)
                .Include(r => r.Library)
                    .ThenInclude(l => l.Book)
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

            // позволяваме ревю само ако книгата е прочетена
            if (library.ShelfType != ShelfType.Read)
                return null;
            else
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return review;
            }

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
            if (review == null) return false;

            review.IsDeleted = true;
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync() > 0;
        }


        //// Изтриване на ревю
        //public async Task<bool> DeleteReviewAsync(int id)
        //{
        //    var review = await GetReviewByIdAsync(id);
        //    if (review == null) return false;

        //    _context.Reviews.Remove(review);
        //    return await _context.SaveChangesAsync() > 0;
        //}
    }
}
