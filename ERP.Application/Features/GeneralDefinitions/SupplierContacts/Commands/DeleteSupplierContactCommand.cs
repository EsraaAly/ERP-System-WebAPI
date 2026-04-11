namespace ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.DeleteSupplierContact
{
    public class DeleteSupplierContactCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierContactHandler : IRequestHandler<DeleteSupplierContactCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierContacts.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("SupplierContact not found");
            }

            var deleted = await _unitOfWork.SupplierContacts.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "SupplierContact deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete SupplierContact");
        }
    }

    public class DeleteSupplierContactValidator : AbstractValidator<DeleteSupplierContactCommand>
    {
        public DeleteSupplierContactValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
