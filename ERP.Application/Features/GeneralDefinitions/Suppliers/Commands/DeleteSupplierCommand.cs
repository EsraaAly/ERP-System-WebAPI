namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Supplier not found");
            }

            var deleted = await _unitOfWork.Suppliers.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Supplier deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Supplier");
        }
    }

    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
