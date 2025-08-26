using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BookWarms.Services
{
    //
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Взимане на всички потребители
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Взимане на потребител по Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Добавяне на потребител (ще го правиш ръчно като админ)
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Обновяване на потребител
        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        // Soft delete
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.IsDeleted) return false;

            user.IsDeleted = true;
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        //// Изтриване на потребител
        //public async Task<bool> DeleteUserAsync(int id)
        //{
        //    var user = await GetUserByIdAsync(id);
        //    if (user == null) return false;

        //    _context.Users.Remove(user);
        //    return await _context.SaveChangesAsync() > 0;
        //}

    }
}

