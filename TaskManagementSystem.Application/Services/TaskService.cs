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
        private readonly IMapper _mapper;
        private readonly ILogger<TaskService> _logger;
        public TaskService(ITaskRepository taskRepository, IMapper mapper, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
        {
            _logger.LogInformation("Fetching all tasks...");
            var tasks = await _taskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int id)
        {
            _logger.LogInformation("Fetching task with ID: {TaskId}", id);
            var task = await _taskRepository.GetByIdAsync(id)
                ?? throw new TaskNotFoundException($"Task with id: {id} not found");
            return _mapper.Map<TaskDTO>(task);
        }
        public async Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO)
        {

            if (string.IsNullOrWhiteSpace(taskDTO.Title))
            {
                throw new InvalidTaskDataException("Task title cannot be empty");
            }
            var taskItem = _mapper.Map<TaskItem>(taskDTO);
            await _taskRepository.AddAsync(taskItem);
            _logger.LogInformation("Task with ID {TaskId} added successfully", taskItem.Id);
            return _mapper.Map<TaskDTO>(taskItem);
        }
        public async Task<TaskDTO> UpdateTaskAsync(TaskDTO taskDTO)
        {
            var taskItem = await _taskRepository.GetByIdAsync(taskDTO.Id)
                ?? throw new TaskNotFoundException($"Task with ID {taskDTO.Id} not found.");
            _mapper.Map(taskDTO, taskItem);
            await _taskRepository.UpdateAsync(taskItem);
            _logger.LogInformation("Task updated successfully: {TaskId}", taskItem.Id);
            return _mapper.Map<TaskDTO>(taskItem);
        }
        public async Task DeleteTaskByIdAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
            _logger.LogInformation("Task deleted successfully: {TaskId}", id);
        }

    }
}
