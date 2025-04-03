namespace TaskManagementSystem.Domain.CustomExceptions
{
    /*
     * Base exception class providing HTTP status code support for custom exceptions.
     */
    public abstract class CustomException: Exception
    {
        public int StatusCode { get; }

        protected CustomException(string message, int statusCode): base(message)
        {
            StatusCode = statusCode;
        }
        protected CustomException(string message, int statusCode, Exception innerException)
            :base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
