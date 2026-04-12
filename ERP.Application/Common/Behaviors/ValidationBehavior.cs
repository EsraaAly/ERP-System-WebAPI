using MediatR;
using FluentValidation;
using ERP.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace ERP.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IHttpContextAccessor httpContextAccessor = null)
        {
            _validators = validators;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                
                // Add user role information for conditional validation
                if (_httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
                {
                    var userRole = _httpContextAccessor.HttpContext.User.FindFirst("role")?.Value ?? "User";
                    var userId = _httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value;
                    
                    context.RootContextData["UserRole"] = userRole;
                    context.RootContextData["UserId"] = userId;
                }

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // Filter validation failures based on user role
                var filteredFailures = FilterFailuresByRole(failures, context.RootContextData);

                if (filteredFailures.Count != 0)
                {
                    throw new ValidationException(filteredFailures);
                }
            }
            return await next();
        }

        private List<FluentValidation.Results.ValidationFailure> FilterFailuresByRole(
            List<FluentValidation.Results.ValidationFailure> failures, 
            IDictionary<string, object> contextData)
        {
            if (!contextData.ContainsKey("UserRole"))
                return failures;

            var userRole = contextData["UserRole"]?.ToString();
            
            // Admin users see all validation errors
            if (userRole == "Admin" || userRole == "SystemAdmin")
                return failures;

            // Filter out admin-only validation errors for regular users
            return failures.Where(f => !f.ErrorMessage.Contains("[Admin Only]") && !f.PropertyName.Contains("Admin")).ToList();
        }
    }
}
