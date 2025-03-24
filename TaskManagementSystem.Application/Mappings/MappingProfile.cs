using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //task mapping
            CreateMap<TaskItem, TaskDTO>().ReverseMap();

            //user mapping
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
