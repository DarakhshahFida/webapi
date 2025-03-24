using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.CustomExceptions
{
    public class InvalidTaskDataException: Exception
    {
        public InvalidTaskDataException(): base("Invalid task data provided")
        {
        }
        public InvalidTaskDataException(string? message) : base(message)
        {
        }
        public InvalidTaskDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
