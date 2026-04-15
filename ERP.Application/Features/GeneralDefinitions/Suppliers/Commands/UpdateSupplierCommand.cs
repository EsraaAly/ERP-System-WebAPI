using ERP.Application.Common.Interfaces.Services;
namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<Result<GetSupplierDto>>
    {
        public int Id { get; set; }
        public UpdateSupplierDto _updateSupplierDTO { get; set; }
    }

    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, Result<GetSupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public UpdateSupplierHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<GetSupplierDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdWithIncludesAsync(request.Id, x => x.Contacts, x => x.Items);
            if (entity == null)
            {
                return Result<GetSupplierDto>.Failure("Supplier not found");
            }

            // Sync child collections and files in a helper method to keep Handle clean
            await SyncSupplierDataAsync(entity, request._updateSupplierDTO);

            // Final Save
            var success = await _unitOfWork.Suppliers.UpdateEntityAsync(entity);
            if (success)
            {
                await _unitOfWork.CommitAsync();
                
                var responseDto = entity.Adapt<GetSupplierDto>();
                
                // Load the updated file paths for the response
                string folderName = "Suppliers\\S-" + entity.Id;
                var files = await _fileStorageService.GetFilesAsync(folderName);
                if (files != null && files.Any())
                {
                    var fileAttachments = new List<FileAttachmentDto>();
                    foreach (var f in files)
                    {
                        fileAttachments.Add(new FileAttachmentDto
                        {
                            FileName = f,
                            FilePath = await _fileStorageService.GetFullPath(folderName, f)
                        });
                    }
                    responseDto.FilePaths = fileAttachments;
                }

                return Result<GetSupplierDto>.Success(responseDto, "Supplier updated successfully");
            }

            return Result<GetSupplierDto>.Failure("Failed to update Supplier");
        }

        private async Task SyncSupplierDataAsync(Supplier entity, UpdateSupplierDto dto)
        {
            // 1. Identify missing items for Soft Delete
            var incomingContactIds = dto.Contacts.Select(c => c.Id).ToList();
            var contactsToDelete = entity.Contacts.Where(c => c.Id != 0 && !incomingContactIds.Contains(c.Id)).ToList();

            var incomingItemIds = dto.Items.Select(i => i.Id).ToList();
            var itemsToDelete = entity.Items.Where(i => i.Id != 0 && !incomingItemIds.Contains(i.Id)).ToList();

            // 2. Map updates and additions
            dto.Adapt(entity);
            entity.UpdatedBy = "SystemAudit";
            entity.UpdatedDate = DateTime.UtcNow;

            // 3. Execute Soft Deletes
            foreach (var contact in contactsToDelete) await _unitOfWork.SupplierContacts.DeleteEntityAsync(contact.Id);
            foreach (var item in itemsToDelete) await _unitOfWork.SupplierItems.DeleteEntityAsync(item.Id);

            // 4. Handle File Sync
            if (dto.FilePaths != null)
            {
                string folderName = "Suppliers\\S-" + entity.Id;
                await _fileStorageService.DeleteFolderAsync(folderName);
                foreach (var file in dto.FilePaths)
                {
                    if (!string.IsNullOrEmpty(file.FilePath))
                        await _fileStorageService.UploadFileAsync(folderName, file.FilePath + "\\" + file.FileName);
                }
            }
        }
    }

    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierDTO).NotNull().WithMessage("Supplier data is required");

            When(x => x._updateSupplierDTO != null, () =>
            {
                RuleFor(x => x._updateSupplierDTO.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x._updateSupplierDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateSupplierDTO.Email)).WithMessage("Invalid email format");
            });
        }
    }
}
