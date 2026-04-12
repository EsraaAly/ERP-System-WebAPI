namespace ERP.Application.Features.GeneralDefinitions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Countries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Country not found");
            }

            var deleted = await _unitOfWork.Countries.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Country deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Country");
        }
    }

    public class DeleteCountryValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
