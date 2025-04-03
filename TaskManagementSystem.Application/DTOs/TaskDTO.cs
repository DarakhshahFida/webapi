using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Application.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public string? Priority { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; } 
        public int? UserId { get; set; } 

    }
}
