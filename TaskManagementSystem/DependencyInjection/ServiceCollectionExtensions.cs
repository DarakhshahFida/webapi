using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Mappings;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Register Application services
            services.AddScoped<ITaskService, TaskService>(); //scoped > one instance per http request
            services.AddScoped<IUserService, UserService>();

            //Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            //register AppDbContext using SQL Server
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //register repositories
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }
    }
}
