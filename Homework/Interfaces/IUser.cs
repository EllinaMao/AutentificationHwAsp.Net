using Homework.Models;

namespace Homework.Interfaces
{
    public interface IUser
    {
        Task<User> GetUserAsync(string email, string password);
        Task RegisterAsync(User user, string password);
    }
}
