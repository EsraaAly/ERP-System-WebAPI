

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

    }
}
