using ERP.Api.Extensions;
using ERP.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.Base
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> HandleCommand<TCommand, TResult>(TCommand command)
            where TCommand : IRequest<Result<TResult>>
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        protected async Task<IActionResult> HandleQuery<TQuery, TResult>(TQuery query)
            where TQuery : IRequest<Result<TResult>>
        {
            var result = await _mediator.Send(query);
            return result.ToActionResult();
        }

        protected async Task<IActionResult> HandleQueryWithData<TQuery, TResult>(TQuery query)
            where TQuery : IRequest<Result<TResult>>
        {
            var result = await _mediator.Send(query);
            return result.ToActionResultWithData();
        }

        protected async Task<IActionResult> HandlePagedQuery<TQuery, TResult>(TQuery query, int totalCount, int pageNumber, int pageSize)
            where TQuery : IRequest<Result<List<TResult>>>
        {
            var result = await _mediator.Send(query);
            return result.ToPagedActionResult(totalCount, pageNumber, pageSize);
        }

        //protected IActionResult ValidationError(string message, List<string> errors)
        //{
        //    var result = Result.UnprocessableEntity(message, errors);
        //    return result.ToActionResult();
        //}

        //protected IActionResult NotFound(string message = "Resource not found")
        //{
        //    var result = Result.NotFound(message);
        //    return result.ToActionResult();
        //}

        //protected IActionResult BadRequest(string message, List<string>? errors = null)
        //{
        //    var result = Result.BadRequest(message, errors);
        //    return result.ToActionResult();
        //}

        //protected IActionResult Unauthorized(string message = "Unauthorized access")
        //{
        //    var result = Result.Unauthorized(message);
        //    return result.ToActionResult();
        //}

        //protected IActionResult Forbidden(string message = "Access forbidden")
        //{
        //    var result = Result.Forbidden(message);
        //    return result.ToActionResult();
        //}

        //protected IActionResult Conflict(string message = "Resource conflict")
        //{
        //    var result = Result.Conflict(message);
        //    return result.ToActionResult();
        //}

        //protected IActionResult InternalServerError(string message = "Internal server error")
        //{
        //    var result = Result.InternalServerError(message);
        //    return result.ToActionResult();
        //}
    }
}
