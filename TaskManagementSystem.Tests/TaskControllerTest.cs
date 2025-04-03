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
            //creates mock object of ITaskService so that we can simulate its behavior.
            _mockService = new Mock<ITaskService>();
            _controller = new TaskController(_mockService.Object); //Object =  gives the actual mocked instance of ITaskService
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

            // Mock the service method to return our predefined list - tasks
            _mockService.Setup(service => service.GetAllTasksAsync()).ReturnsAsync(tasks);

            // Act: Call the controller method
            var result = await _controller.GetAllTasks();

            // Assert: Check if the result is OkObjectResult -  (HTTP 200 OK response)
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Extract the value and ensure it is of type List<TaskDTO>
            var returnedTasks = Assert.IsType<List<TaskDTO>>(okResult.Value);

            // Verify the count matches expected data
            Assert.Equal(2, returnedTasks.Count);
        }
    }
}
