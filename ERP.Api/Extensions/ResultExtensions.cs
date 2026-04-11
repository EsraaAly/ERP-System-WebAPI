namespace ERP.Api.Extensions
{
    public static class ResultExtensions
    {
        private static IActionResult CreateResult(int statusCode, object responseBody)
        {
            return statusCode switch
            {
                StatusCodes.Status200OK => new OkObjectResult(responseBody),
                StatusCodes.Status201Created => new CreatedResult("", responseBody),
                StatusCodes.Status204NoContent => new NoContentResult(),
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(responseBody),
                StatusCodes.Status401Unauthorized => new UnauthorizedObjectResult(responseBody),
                StatusCodes.Status403Forbidden => new ForbidResult(),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(responseBody),
                StatusCodes.Status409Conflict => new ConflictObjectResult(responseBody),
                StatusCodes.Status422UnprocessableEntity => new UnprocessableEntityObjectResult(responseBody),
                _ => new ObjectResult(responseBody) { StatusCode = statusCode }
            };
        }

        public static IActionResult ToActionResult(this Result result)
            => CreateResult(result.StatusCode, result);

        public static IActionResult ToActionResult<T>(this Result<T> result)
            => CreateResult(result.StatusCode, result);
        public static IActionResult ToActionResultWithData<T>(this Result<T> result)
        {
            if (result.IsSuccess && result.Data != null)
            {
                return CreateResult(result.StatusCode, result);
            }
            return result.ToActionResult();
        }

        public static IActionResult ToPagedActionResult<T>(this Result<List<T>> result, int totalCount, int pageNumber, int pageSize)
        {
            var pagedResult = new
            {
                result.Data,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                HasNextPage = pageNumber * pageSize < totalCount,
                HasPreviousPage = pageNumber > 1,
                result.IsSuccess,
                result.Message,
                result.Errors
            };

            return CreateResult(result.StatusCode, pagedResult);
        }
    }
}