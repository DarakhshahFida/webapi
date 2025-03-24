using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Controllers;
using Xunit;

namespace TaskManagementSystem.Tests
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _mockService;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _mockService = new Mock<ITaskService>();
            _controller = new TaskController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithList()
        {
            // Arrange: Create a list of TaskDTOs
            var tasks = new List<TaskDTO>
            {
                new TaskDTO { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.UtcNow, Priority = "High", Status = "Pending", UserId = 101 },
                new TaskDTO { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.UtcNow.AddDays(2), Priority = "Medium", Status = "Completed", UserId = 102 }
            };

            // Mock the service method to return the tasks
            _mockService.Setup(service => service.GetAllTasksAsync()).ReturnsAsync(tasks);

            // Act: Call the controller method (ensure it's awaited)
            var result = await _controller.GetAllTasks();

            // Assert: Check if the result is OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Extract the value and ensure it is of type List<TaskDTO>
            var returnedTasks = Assert.IsType<List<TaskDTO>>(okResult.Value);

            // Verify the count matches expected data
            Assert.Equal(2, returnedTasks.Count);
        }
    }
}
