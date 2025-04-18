﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Domain.CustomExceptions;

namespace TaskManagementSystem.Application.Services
{
    // Manages user-related operations including authentication.
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            if (string.IsNullOrEmpty(registerDTO.UserName) || 
                string.IsNullOrEmpty(registerDTO.Email) || 
                string.IsNullOrEmpty(registerDTO.Password))
            {
                throw new InvalidTaskDataException("Username, Email, and Password are required.");
            }
            var user = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                //PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                PasswordHash = registerDTO.Password,
                Role = "User"

            };
            await _userRepository.AddAsync(user);
            _logger.LogInformation("User registered successfully: {UserId}", user.Id);
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            };

        }
        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetByEmailAsync(loginDTO.Email) 
                ?? throw new UserNotFoundException($"User with email {loginDTO.Email} not found.");
            if (user.PasswordHash != loginDTO.Password)
            {
                throw new InvalidTaskDataException("Invalid password.");
            }
            //set up user authentication by using cookies to store the session ID directly in the user's browser.
            var httpContext = _httpContextAccessor.HttpContext;

            //set a cookie with the user's id
            httpContext.Response.Cookies.Append("UserId", user.Id.ToString());
            _logger.LogInformation("User logged in successfully: {Email}", loginDTO.Email);

            return true;
        }
    }
}
