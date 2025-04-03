using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(RegisterDTO registerDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
    }
}
