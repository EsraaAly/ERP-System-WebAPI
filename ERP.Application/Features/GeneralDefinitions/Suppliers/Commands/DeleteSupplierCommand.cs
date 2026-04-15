using ERP.Application.Common.Interfaces.Services;
namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public DeleteSupplierHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdWithIncludesAsync(request.Id, x => x.Contacts, x => x.Items);

            if (entity == null)
            {
                return Result<bool>.Failure("Supplier not found");
            }

            var deleted = await _unitOfWork.Suppliers.DeleteEntityAsync(request.Id);

            if (deleted)
            {
                // Mark each related Contact as deleted
                foreach (var contact in entity.Contacts)
                {
                    await _unitOfWork.SupplierContacts.DeleteEntityAsync(contact.Id);
                }

                // Mark each related Item as deleted
                foreach (var item in entity.Items)
                {
                    await _unitOfWork.SupplierItems.DeleteEntityAsync(item.Id);
                }

                // Delete the folder associated with this supplier from storage
                string folderName = "Suppliers\\S-" + entity.Id;
                await _fileStorageService.DeleteFolderAsync(folderName);

                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Supplier and all related data (including files) deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Supplier");
        }
    }

    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
