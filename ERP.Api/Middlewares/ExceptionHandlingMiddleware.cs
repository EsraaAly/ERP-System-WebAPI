using ERP.Application.Common.Models;
using ERP.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

            // Handle DbUpdateException and convert to ValidationException
            if (exception is DbUpdateException dbUpdateException)
            {
                code = HttpStatusCode.BadRequest; // 400
                message = "Database validation failed";
                errors = ExtractDatabaseErrors(dbUpdateException);
            }
            // Check if error is from ValidationBehavior (FluentValidation)
            else if (exception is FluentValidation.ValidationException fluentValidationException)
            {
                code = HttpStatusCode.BadRequest; // 400
                message = "Validation Failed";
                errors = fluentValidationException.Errors.Select(e => e.ErrorMessage).ToList();
            }
            // Check if error is our custom ValidationException
            else if (exception is ERP.Application.Common.Exceptions.ValidationException customValidationException)
            {
                code = HttpStatusCode.BadRequest; // 400
                message = "Validation Failed";
                errors = customValidationException.Errors;
            }
            else
            {
                // Generic exception
                errors.Add(exception.Message);
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

        private static List<string> ExtractDatabaseErrors(DbUpdateException dbUpdateException)
        {
            var errors = new List<string>();

            // Handle unique constraint violations
            if (dbUpdateException.InnerException != null)
            {
                var innerMessage = dbUpdateException.InnerException.Message;
                
                if (innerMessage.Contains("unique") || innerMessage.Contains("duplicate"))
                {
                    errors.Add("A record with this value already exists. Please ensure all fields are unique as required.");
                }
                else if (innerMessage.Contains("foreign key") || innerMessage.Contains("reference"))
                {
                    errors.Add("Invalid reference. The referenced record does not exist.");
                }
                else if (innerMessage.Contains("cannot be null") || innerMessage.Contains("not null"))
                {
                    errors.Add("Required field cannot be empty.");
                }
                else if (innerMessage.Contains("too long") || innerMessage.Contains("maximum length"))
                {
                    errors.Add("One or more fields exceed the maximum allowed length.");
                }
                else
                {
                    errors.Add($"Database constraint violation: {innerMessage}");
                }
            }
            else
            {
                errors.Add("Database operation failed. Please check your data and try again.");
            }

            return errors;
        }
    }
}
