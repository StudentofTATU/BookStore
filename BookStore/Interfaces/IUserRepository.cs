using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByIdAsync(int userId);

        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
