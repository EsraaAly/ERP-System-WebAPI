
namespace ERP.Application.Common.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public static Result Success(string message = "Operation completed successfully")
        {
            return new Result { IsSuccess = true, Message = message, StatusCode = StatusCodes.Status200OK };
        }

        public static Result Created(string message = "Resource created successfully")
        {
            return new Result { IsSuccess = true, Message = message, StatusCode = StatusCodes.Status201Created };
        }

        public static Result NoContent(string message = "Operation completed successfully")
        {
            return new Result { IsSuccess = true, Message = message, StatusCode = StatusCodes.Status204NoContent };
        }

        public static Result BadRequest(string message, List<string>? errors = null)
        {
            return new Result { IsSuccess = false, Message = message, Errors = errors ?? new List<string>(), StatusCode = StatusCodes.Status400BadRequest };
        }

        public static Result Unauthorized(string message = "Unauthorized access")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status401Unauthorized };
        }

        public static Result Forbidden(string message = "Access forbidden")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status403Forbidden };
        }

        public static Result NotFound(string message = "Resource not found")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status404NotFound };
        }

        public static Result Conflict(string message = "Resource conflict")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status409Conflict };
        }

        public static Result UnprocessableEntity(string message, List<string>? errors = null)
        {
            return new Result { IsSuccess = false, Message = message, Errors = errors ?? new List<string>(), StatusCode = StatusCodes.Status422UnprocessableEntity };
        }

        public static Result InternalServerError(string message = "Internal server error")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status500InternalServerError };
        }

        public static Result ServiceUnavailable(string message = "Service unavailable")
        {
            return new Result { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status503ServiceUnavailable };
        }

        public static Result Failure(string message, List<string>? errors = null)
        {
            return BadRequest(message, errors);
        }
    }

    public class Result<T> : Result
    {
        public T? Data { get; set; }

        public static Result<T> Success(T data, string message = "Operation completed successfully")
        {
            return new Result<T> { IsSuccess = true, Message = message, Data = data, StatusCode = StatusCodes.Status200OK };
        }

        public static Result<T> Created(T data, string message = "Resource created successfully")
        {
            return new Result<T> { IsSuccess = true, Message = message, Data = data, StatusCode = StatusCodes.Status201Created };
        }

        public static Result<T> BadRequest(string message, List<string>? errors = null)
        {
            return new Result<T> { IsSuccess = false, Message = message, Errors = errors ?? new List<string>(), StatusCode = StatusCodes.Status400BadRequest };
        }

        public static Result<T> Unauthorized(string message = "Unauthorized access")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status401Unauthorized };
        }

        public static Result<T> Forbidden(string message = "Access forbidden")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status403Forbidden };
        }

        public static Result<T> NotFound(string message = "Resource not found")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status404NotFound };
        }

        public static Result<T> Conflict(string message = "Resource conflict")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status409Conflict };
        }

        public static Result<T> UnprocessableEntity(string message, List<string>? errors = null)
        {
            return new Result<T> { IsSuccess = false, Message = message, Errors = errors ?? new List<string>(), StatusCode = StatusCodes.Status422UnprocessableEntity };
        }

        public static Result<T> InternalServerError(string message = "Internal server error")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status500InternalServerError };
        }

        public static Result<T> ServiceUnavailable(string message = "Service unavailable")
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = StatusCodes.Status503ServiceUnavailable };
        }

        public static Result<T> Failure(string message, List<string>? errors = null)
        {
            return BadRequest(message, errors);
        }
    }
}
