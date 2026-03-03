using Homework.Models;
using Homework.ViewModels;

namespace Homework.Extensions
{
    public static class MappingExtensions
    {
        // User -> UserViewModel (если потребуется в будущем)
        
        // RegisterViewModel -> User
        public static User ToUser(this RegisterViewModel model)
        {
            return new User
            {
                Email = model.Email,
                Age = model.Age,
                Company = model.Company ?? string.Empty
            };
        }

        // TaskItemViewModel -> TaskItem
        public static TaskItem ToTaskItem(this TaskItemViewModel model, int userId)
        {
            return new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                IsDone = model.IsDone,
                UserId = userId
            };
        }

        // TaskItem -> TaskItemViewModel
        public static TaskItemViewModel ToViewModel(this TaskItem task)
        {
            return new TaskItemViewModel
            {
                Title = task.Title,
                Description = task.Description,
                IsDone = task.IsDone
            };
        }
    }
}
