using Homework.Data;
using Homework.Models;
using Homework.Interfaces;

using Microsoft.EntityFrameworkCore;

public class TaskRepository : ITask
{
    private readonly ApplicationDbContext _db;
    public TaskRepository(ApplicationDbContext db) => _db = db;

    public async Task<List<TaskItem>> GetTasksAsync(int userId, string search)
    {
        var query = _db.Tasks.Where(t => t.UserId == userId);
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(t => t.Title.Contains(search));
        }
        return await query.ToListAsync();
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId, int userId)
    {
        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }
    }
}