using BookWarms.Data;
using BookWarms.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWarms.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) => _context = context;

        public async Task<List<User>> GetAllUsersAsync()
            => await _context.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user.IsDeleted) return false;
            user.IsDeleted = true;
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RestoreUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted);
            if (user == null) return false;
            user.IsDeleted = false;
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

