using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Data
{
    //DbContext: base class in EF Core for interacting with the database.
    //  helps configure the database schema and manage entity relationships.
    public class AppDbContext: DbContext
    {
        //The constructor initializes the DbContext using the provided options.
        //DbContextOptions<AppDbContext> = configuration object that contains settings such as the database provider (SQL Server, PostgreSQL, etc.), connection string, logging options, and more.
        // It is passed from the dependency injection (DI) container when the application starts.
        // : base(options) = calls the base class constructor in DbContext, passing the options object to it.
        // DbContext will then use these options to configure itself.
        //We need this constructor because EF Core relies on dependency injection to configure the DbContext. The constructor allows the options to be injected when registering AppDbContext in Program.cs
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        // OnModelCreating = This method is called when EF Core is building the database model.
        // It allows us to define relationships, constraints, default values, indexes, and more.
        // It's overridden in AppDbContext to customize how entities map to the database.
        // Why call this??? it ensures that EF Core's default behavior is applied before adding custom configurations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>()
    .Property(t => t.Priority)
    .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Status)
                .IsRequired();

            //// Configure the relationship between TaskItem and User
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User) //TaskItem has one User
                .WithMany() //User can have many TaskItem
                .HasForeignKey(t => t.UserId) //Foreign Key in TaskItem
                .OnDelete(DeleteBehavior.Cascade); //Delete TaskItems when User is deleted
        }
        
    }

}
