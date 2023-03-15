using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);

        bool Add(User user);
        bool Update(User user);
        bool Delete(int userId);
        bool Save();
    }
}
