using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class LibraryService
    {
        private readonly AppDbContext _context;

        public LibraryService(AppDbContext context)
        {
            _context = context;
        }

        // Взимане на всички книги от библиотеката на даден user
        public async Task<List<Library>> GetUserLibraryAsync(int userId)
        {
            return await _context.Libraries
                .Include(l => l.Book)
                .Where(l => l.UserId == userId && !l.IsDeleted)
                .ToListAsync();
        }

        // Добавяне на книга в библиотеката
        public async Task<Library?> AddBookAsync(int userId, int bookId, ShelfType shelfType)
        {
            var existing = await _context.Libraries
                .FirstOrDefaultAsync(l => l.UserId == userId && l.BookId == bookId && !l.IsDeleted);

            if (existing != null) return null; 

            var library = new Library
            {
                UserId = userId,
                BookId = bookId,
                ShelfType = shelfType,
                IsDeleted = false
            };

            _context.Libraries.Add(library);
            await _context.SaveChangesAsync();
            return library;
        }

        // Обновяване на рафта (например WantToRead -> CurrentlyReading)
        public async Task<Library?> UpdateShelfAsync(int id, ShelfType newShelf)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null || library.IsDeleted) return null;

            library.ShelfType = newShelf;
            await _context.SaveChangesAsync();
            return library;
        }

        // soft delete
        public async Task<bool> DeleteAsync(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null || library.IsDeleted) return false;

            library.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}