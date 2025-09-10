using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context) => _context = context;

        public async Task<Book?> GetBookByIdAsync(int id)
            => await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

        public async Task<List<Book>> GetAllBooksAsync()
            => await _context.Books.AsNoTracking().Where(b => !b.IsDeleted).ToListAsync();

        public async Task<PagedResult<Book>> SearchAsync(string? query, string? sortBy, bool desc, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            IQueryable<Book> q = _context.Books.AsNoTracking().Where(b => !b.IsDeleted);

            if (!string.IsNullOrWhiteSpace(query))
            {
                var t = query.Trim();
                q = q.Where(b =>
                    EF.Functions.Like(b.Title, $"%{t}%") ||
                    EF.Functions.Like(b.Author, $"%{t}%") ||
                    EF.Functions.Like(b.Genre, $"%{t}%") ||
                    EF.Functions.Like(b.Description, $"%{t}%"));
            }

            q = (sortBy?.ToLowerInvariant()) switch
            {
                "author" => desc ? q.OrderByDescending(b => b.Author) : q.OrderBy(b => b.Author),
                "genre" => desc ? q.OrderByDescending(b => b.Genre) : q.OrderBy(b => b.Genre),
                "pagecount" => desc ? q.OrderByDescending(b => b.PageCount) : q.OrderBy(b => b.PageCount),
                _ => desc ? q.OrderByDescending(b => b.Title) : q.OrderBy(b => b.Title),
            };

            var total = await q.CountAsync();
            var items = await q.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Book>
            {
                Items = items,
                TotalCount = total,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var existing = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id && !b.IsDeleted);
            if (existing == null) return false;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Genre = book.Genre;
            existing.Description = book.Description;
            existing.PageCount = book.PageCount;

            _context.Books.Update(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
            if (book == null) return false;
            book.IsDeleted = true;
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RestoreBookAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted);
            if (book == null) return false;
            book.IsDeleted = false;
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public List<Book> GetAllBooks()
            => _context.Books.AsNoTracking().Where(b => !b.IsDeleted).ToList();
    }
}
