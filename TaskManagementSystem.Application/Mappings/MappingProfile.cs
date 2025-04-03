using AutoMapper;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Mappings
{
    // Define mapping configurations between domain entities and DTOs.
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
