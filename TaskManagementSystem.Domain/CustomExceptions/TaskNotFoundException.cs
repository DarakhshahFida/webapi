using Microsoft.AspNetCore.Http;


namespace TaskManagementSystem.Domain.CustomExceptions
{
    /*
     * Thrown when a task is not found.
     */
    public class TaskNotFoundException: CustomException
    {
        public TaskNotFoundException(string message) 
            : base(message, StatusCodes.Status404NotFound) { }
    }
}
