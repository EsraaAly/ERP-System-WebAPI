
using ERP.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this Result result)
        {
            return result.StatusCode switch
            {
                StatusCodes.Status200OK => new OkObjectResult(result),
                StatusCodes.Status201Created => new CreatedResult("", result),
                StatusCodes.Status204NoContent => new NoContentResult(),
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(result),
                StatusCodes.Status401Unauthorized => new UnauthorizedObjectResult(result),
                StatusCodes.Status403Forbidden => new ForbidResult(),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(result),
                StatusCodes.Status409Conflict => new ConflictObjectResult(result),
                StatusCodes.Status422UnprocessableEntity => new UnprocessableEntityObjectResult(result),
                StatusCodes.Status500InternalServerError => new ObjectResult(result) { StatusCode = StatusCodes.Status500InternalServerError },
                StatusCodes.Status503ServiceUnavailable => new ObjectResult(result) { StatusCode = StatusCodes.Status503ServiceUnavailable },
                _ => new ObjectResult(result) { StatusCode = result.StatusCode }
            };
        }

        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            return result.StatusCode switch
            {
                StatusCodes.Status200OK => new OkObjectResult(result),
                StatusCodes.Status201Created => new CreatedResult("", result),
                StatusCodes.Status204NoContent => new NoContentResult(),
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(result),
                StatusCodes.Status401Unauthorized => new UnauthorizedObjectResult(result),
                StatusCodes.Status403Forbidden => new ForbidResult(),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(result),
                StatusCodes.Status409Conflict => new ConflictObjectResult(result),
                StatusCodes.Status422UnprocessableEntity => new UnprocessableEntityObjectResult(result),
                StatusCodes.Status500InternalServerError => new ObjectResult(result) { StatusCode = StatusCodes.Status500InternalServerError },
                StatusCodes.Status503ServiceUnavailable => new ObjectResult(result) { StatusCode = StatusCodes.Status503ServiceUnavailable },
                _ => new ObjectResult(result) { StatusCode = result.StatusCode }
            };
        }

        public static IActionResult ToActionResultWithData<T>(this Result<T> result)
        {
            if (result.IsSuccess && result.Data != null)
            {
                return result.StatusCode switch
                {
                    StatusCodes.Status200OK => new OkObjectResult(result.Data),
                    StatusCodes.Status201Created => new CreatedResult("", result.Data),
                    StatusCodes.Status204NoContent => new NoContentResult(),
                    _ => new ObjectResult(result.Data) { StatusCode = result.StatusCode }
                };
            }

            return result.ToActionResult();
        }

        public static IActionResult ToPagedActionResult<T>(this Result<List<T>> result, int totalCount, int pageNumber, int pageSize)
        {
            var pagedResult = new
            {
                Data = result.Data,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                HasNextPage = pageNumber * pageSize < totalCount,
                HasPreviousPage = pageNumber > 1,
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Errors = result.Errors
            };

            return result.StatusCode switch
            {
                StatusCodes.Status200OK => new OkObjectResult(pagedResult),
                StatusCodes.Status201Created => new CreatedResult("", pagedResult),
                StatusCodes.Status204NoContent => new NoContentResult(),
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(pagedResult),
                StatusCodes.Status401Unauthorized => new UnauthorizedObjectResult(pagedResult),
                StatusCodes.Status403Forbidden => new ForbidResult(),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(pagedResult),
                StatusCodes.Status409Conflict => new ConflictObjectResult(pagedResult),
                StatusCodes.Status422UnprocessableEntity => new UnprocessableEntityObjectResult(pagedResult),
                StatusCodes.Status500InternalServerError => new ObjectResult(pagedResult) { StatusCode = StatusCodes.Status500InternalServerError },
                StatusCodes.Status503ServiceUnavailable => new ObjectResult(pagedResult) { StatusCode = StatusCodes.Status503ServiceUnavailable },
                _ => new ObjectResult(pagedResult) { StatusCode = result.StatusCode }
            };
        }
    }
}
