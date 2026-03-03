using System.ComponentModel.DataAnnotations;

namespace Homework.ViewModels
{
    public class TaskItemViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
