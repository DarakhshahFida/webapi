using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    /*
     * Represents a task in the system.
     */
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

    }
}
