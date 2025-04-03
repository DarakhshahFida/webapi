using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    /*
     * Represents a user in the system.
     */
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
