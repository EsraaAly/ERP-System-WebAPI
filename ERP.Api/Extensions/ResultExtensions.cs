
namespace ERP.Api.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(result);
            }

            return new BadRequestObjectResult(result);
        }
    }
}
