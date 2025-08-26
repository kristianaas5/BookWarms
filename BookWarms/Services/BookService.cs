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
            return await _context.Books.FindAsync(id);
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<bool> UpdateBookAsync(Book book)
        {
            var existing = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (existing == null) return false;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Genre = book.Genre;
            existing.Description = book.Description;
            existing.PageCount = book.PageCount;

            _context.Books.Update(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<bool> DeleteBookAsync(int id)
        //{
        //    var book = await GetBookByIdAsync(id);
        //    if (book == null) return false;
        //    _context.Books.Remove(book);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        // Soft Delete
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return false;

            book.IsDeleted = true;
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
    }
}
