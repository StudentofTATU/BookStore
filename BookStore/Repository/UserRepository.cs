using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(User user)
        {
            _context.Add(user);

            return Save();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == userId);
        }

        public bool Update(User user)
        {
            User updateUser = _context.Users.Find(user.Id);

            updateUser.Name = user.Name;
            updateUser.Password = user.Password;
            updateUser.UserStatus = user.UserStatus;

            return Save();
        }

        public bool Delete(int userId)
        {
            User deleteUser = _context.Users.Find(userId);

            _context.Users.Remove(deleteUser);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }
    }
}
