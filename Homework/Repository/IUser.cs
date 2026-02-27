using Homework.Data;
using Homework.Interfaces;
using Homework.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUser
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db; // Контекст получен через Dependency Injection
    }

    public async Task<User> GetUserAsync(string email, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return isValid ? user : null;
    }
}