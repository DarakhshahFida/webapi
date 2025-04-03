using Microsoft.AspNetCore.Http;

namespace TaskManagementSystem.Domain.CustomExceptions
{
    /*
     * Thrown when a user is not found.
     */
    public class UserNotFoundException: CustomException
    {
        public UserNotFoundException(string message)
            : base(message, StatusCodes.Status404NotFound) { }
    }
}
