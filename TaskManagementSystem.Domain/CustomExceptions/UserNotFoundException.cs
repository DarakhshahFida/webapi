using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.CustomExceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(): base("User not found")
        {
        }
        public UserNotFoundException(string? message) : base(message)
        {
        }
        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
