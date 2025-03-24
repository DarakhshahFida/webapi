using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Domain.CustomExceptions;

namespace TaskManagementSystem.Application.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper mapper;
        private readonly ILogger<TaskService> _logger;
        public TaskService(ITaskRepository taskRepository, IMapper mapper, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            this.mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all tasks");
                var tasks = await _taskRepository.GetAllAsync();
                return mapper.Map<IEnumerable<TaskDTO>>(tasks);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An Error occured while fetching all the tasks");
                throw new Exception("Failed to fetch tasks. Please try again later.");
            }
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching task with ID: {id}");
                var task = await _taskRepository.GetByIdAsync(id) ?? throw new TaskNotFoundException($"Task with id: {id} not found");
                return mapper.Map<TaskDTO>(task);
            }
            catch(TaskNotFoundException)
            {
                throw;
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An error occured while fetching Task with Id: {id}");
                throw new Exception("Failed to fetch task. Please try again later");
            }
        }
        public async Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(taskDTO.Title))
                {
                    throw new InvalidTaskDataException("Title is required");
                }
                var taskItem = mapper.Map<TaskItem>(taskDTO);
                await _taskRepository.AddAsync(taskItem);
                _logger.LogInformation($"Task with Id: {taskItem.Id} added successfully");
                return mapper.Map<TaskDTO>(taskItem);
            }
            catch(InvalidTaskDataException)
            {
                throw;
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"An error occured while adding a new task with title {taskDTO.Title}");
                throw new Exception("Failed to add task. Please try again later.");
            }
        }
        public async Task<TaskDTO> UpdateTaskAsync(TaskDTO taskDTO)
        {
            try
            {
                var taskItem = mapper.Map<TaskItem>(taskDTO) ?? throw new TaskNotFoundException($"Task with ID {taskDTO.Id} not found.");
                await _taskRepository.UpdateAsync(taskItem);
                _logger.LogInformation("Task updated successfully: {TaskId}", taskItem.Id);
                return mapper.Map<TaskDTO>(taskItem);
            }
            catch(TaskNotFoundException)
            {
                throw;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An error occurred while updating task with ID {TaskId}", taskDTO.Id);
                throw new Exception("Failed to update task. Please try again later.");
            }

        }
        public async Task DeleteTaskByIdAsync(int id)
        {
            try
            {
                var taskItem = await _taskRepository.GetByIdAsync(id) ?? throw new TaskNotFoundException($"Task with ID {id} not found.");
                await _taskRepository.DeleteAsync(id);
                _logger.LogInformation("Task deleted successfully: {TaskId}", id);
            }
            catch (TaskNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting task with ID {TaskId}", id);
                throw new Exception("Failed to delete task. Please try again later.");
            }
        }

    }
}
