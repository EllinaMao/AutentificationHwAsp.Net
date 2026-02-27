using Homework.Data;
using Homework.Models;
using Homework.Interfaces;

using Microsoft.EntityFrameworkCore;

public class UserRepository : IUser
{
    private readonly ApplicationDbContext _db;
    public UserRepository(ApplicationDbContext db) => _db = db;

    public async Task<User> GetUserAsync(string email, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    public async Task RegisterAsync(User user, string password)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }
}