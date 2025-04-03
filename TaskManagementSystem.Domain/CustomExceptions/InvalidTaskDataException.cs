using Microsoft.AspNetCore.Http;

namespace TaskManagementSystem.Domain.CustomExceptions
{
    /*
     * Thrown when task data is invalid or incomplete
     */
    public class InvalidTaskDataException : CustomException
    {
        public InvalidTaskDataException(string message)
            : base(message, StatusCodes.Status400BadRequest ){ }
    }
}
