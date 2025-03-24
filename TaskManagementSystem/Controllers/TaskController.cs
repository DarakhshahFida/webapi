using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound("Task Not Found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDTO taskDTO)
        {
            var task = await _taskService.AddTaskAsync(taskDTO);
            //return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
            return Ok(task);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskDTO taskDTO)
        {
            if(id != taskDTO.Id)
            {
                return BadRequest("Id Mismatch");
            }
            var updatedTask = await _taskService.UpdateTaskAsync(taskDTO);
            if (updatedTask == null)
            {
                return NotFound("Task not found.");
            }

            return Ok(updatedTask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskByIdAsync(id);
            return Ok("Task Deleted Successfully");
                
        }
    }
}
