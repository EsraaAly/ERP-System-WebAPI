namespace ERP.Application.Features.GeneralDefinitions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Cities.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("City not found");
            }

            var deleted = await _unitOfWork.Cities.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "City deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete City");
        }
    }

    public class DeleteCityValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
