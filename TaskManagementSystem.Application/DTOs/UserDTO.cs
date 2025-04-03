using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Application.DTOs
{
    public class UserDTO
    {
        //general user information.
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        public string? Role { get; set; }
    }

    //For user registration.
    public class RegisterDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }
    }

    //For user login.
    public class LoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
