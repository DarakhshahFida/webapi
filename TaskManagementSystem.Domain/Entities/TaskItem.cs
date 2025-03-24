using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }  // use Priority enum
        public string Status { get; set; } // use Status enum
        public int? UserId { get; set; } //foreign key to User
        public User? User { get; set; } //Navigation property to User


    }
}
