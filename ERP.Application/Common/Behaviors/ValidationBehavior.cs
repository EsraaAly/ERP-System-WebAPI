using MediatR;
using FluentValidation;
using ERP.Application.Common.Models;

namespace ERP.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<Result<TResponse>>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<Result<TResponse>>> validators)
        {
            _validators = validators;
        }

        public async Task<Result<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse>> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    // Convert FluentValidation errors to Result.Failure
                    var errorMessages = failures.Select(f => f.ErrorMessage).ToList();
                    return Result<TResponse>.Failure("Validation failed", errorMessages);
                }
            }
            return await next();
        }
    }
}
