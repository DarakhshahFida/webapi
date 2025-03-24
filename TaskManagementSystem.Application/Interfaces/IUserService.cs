using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(RegisterDTO registerDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
    }
}
