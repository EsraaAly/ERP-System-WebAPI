namespace ERP.Application.Features.GeneralDefinitions.Units.Commands.DeleteUnit
{
    public class DeleteUnitCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Unit.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Unit not found");
            }

            var deleted = await _unitOfWork.Unit.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Unit deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Unit");
        }
    }

    public class DeleteUnitValidator : AbstractValidator<DeleteUnitCommand>
    {
        public DeleteUnitValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
