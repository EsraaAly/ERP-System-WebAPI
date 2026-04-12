using ERP.Application.Common.Models;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ERP.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // Default 500
            var message = "An unexpected error occurred.";
            List<string> errors = new();

            // Check if the error is from ValidationBehavior
            if (exception is ValidationException validationException)
            {
                code = HttpStatusCode.BadRequest; // 400
                message = "Validation Failed";
                errors = validationException.Errors.Select(e => e.ErrorMessage).ToList();
            }

            // Build response with the same structure used in previous images
            var result = new Result<object>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                StatusCode = (int)code
            };

            var response = JsonSerializer.Serialize(result, new JsonSerializerOptions 
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(response);
        }
    }
}
