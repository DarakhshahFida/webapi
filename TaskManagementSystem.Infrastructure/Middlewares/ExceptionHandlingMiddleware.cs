using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskManagementSystem.Domain.CustomExceptions;

namespace TaskManagementSystem.Infrastructure.Middlewares
{
    // Middleware for handling exceptions globally and returning appropriate responses.
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //Core middleware logic
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //call next middleware or controller
                await _next(context);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, "An exception occured");
                await HandleCustomExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occured");
                await HandleGeneralExceptionAsync(context);
            }
        }

        //Exception Processing
        private static Task HandleCustomExceptionAsync(HttpContext context, CustomException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.StatusCode;
            var errorResponse = new
            {
                exception.Message,
                exception.StatusCode
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        private static Task HandleGeneralExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            
            //Default 500 response
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                Message = "An unexpected error occured. Please try again later.",
                StatusCode = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));

        }


    }
}
