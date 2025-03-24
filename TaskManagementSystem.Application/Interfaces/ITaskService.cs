using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(int id);
        Task<TaskDTO> AddTaskAsync(TaskDTO taskdto);
        Task<TaskDTO> UpdateTaskAsync(TaskDTO taskdto);
        Task DeleteTaskByIdAsync(int id);
    }
}
