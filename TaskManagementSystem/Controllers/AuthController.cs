using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = await _userService.RegisterAsync(registerDTO);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var isLoggedIn = await _userService.LoginAsync(loginDTO);
            if (!isLoggedIn)
            {
                return Unauthorized("Invalid Email or Password"); //401 Unauthorized
            }
            return Ok("Logged in successfully");
        }
    }
}
