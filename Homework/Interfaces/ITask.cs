using Homework.Models;

namespace Homework.Interfaces
{
    public interface ITask
    {
        Task<List<TaskItem>> GetTasksAsync(int userId, string search);
        Task AddTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int taskId, int userId);
    }
}
