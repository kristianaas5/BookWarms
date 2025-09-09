using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.AsNoTracking().Where(b => !b.IsDeleted).ToListAsync();
        }

        // Search + sort + paginate (Title|Author|Genre|PageCount)
        public async Task<PagedResult<Book>> SearchAsync(
            string? query, string? sortBy, bool desc, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            IQueryable<Book> books = _context.Books.AsNoTracking().Where(b => !b.IsDeleted);

            if (!string.IsNullOrWhiteSpace(query))
            {
                var q = query.Trim();
                books = books.Where(b =>
                    EF.Functions.Like(b.Title, $"%{q}%") ||
                    EF.Functions.Like(b.Author, $"%{q}%") ||
                    EF.Functions.Like(b.Genre, $"%{q}%") ||
                    EF.Functions.Like(b.Description, $"%{q}%"));
            }

            books = (sortBy?.ToLowerInvariant()) switch
            {
                "author" => desc ? books.OrderByDescending(b => b.Author) : books.OrderBy(b => b.Author),
                "genre" => desc ? books.OrderByDescending(b => b.Genre) : books.OrderBy(b => b.Genre),
                "pagecount" => desc ? books.OrderByDescending(b => b.PageCount) : books.OrderBy(b => b.PageCount),
                _ => desc ? books.OrderByDescending(b => b.Title) : books.OrderBy(b => b.Title),
            };

            var total = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

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

        // Soft Delete
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
            if (book == null) return false;

            book.IsDeleted = true;
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.AsNoTracking().Where(b => !b.IsDeleted).ToList();
        }
    }
}
