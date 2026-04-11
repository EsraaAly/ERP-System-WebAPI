namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.DeleteSupplierItem
{
    public class DeleteSupplierItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierItemHandler : IRequestHandler<DeleteSupplierItemCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierItems.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("SupplierItem not found");
            }

            var deleted = await _unitOfWork.SupplierItems.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "SupplierItem deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete SupplierItem");
        }
    }

    public class DeleteSupplierItemValidator : AbstractValidator<DeleteSupplierItemCommand>
    {
        public DeleteSupplierItemValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
