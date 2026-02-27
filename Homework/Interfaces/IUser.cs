using Homework.Models;

namespace Homework.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email, string password);
        Task RegisterAsync(User user);
        Task<User> GetByIdAsync(int id);
    }
}
