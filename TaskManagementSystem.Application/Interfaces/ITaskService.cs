using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    //Defines business logic operations for tasks, decoupling application logic from data access
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(int id);
        Task<TaskDTO> AddTaskAsync(TaskDTO taskdto);
        Task<TaskDTO> UpdateTaskAsync(TaskDTO taskdto);
        Task DeleteTaskByIdAsync(int id);
    }
}
