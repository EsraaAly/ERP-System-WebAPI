namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.DeleteSupplierType
{
    public class DeleteSupplierTypeCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierTypeHandler : IRequestHandler<DeleteSupplierTypeCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierTypes.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("SupplierType not found");
            }

            var deleted = await _unitOfWork.SupplierTypes.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "SupplierType deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete SupplierType");
        }
    }

    public class DeleteSupplierTypeValidator : AbstractValidator<DeleteSupplierTypeCommand>
    {
        public DeleteSupplierTypeValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
