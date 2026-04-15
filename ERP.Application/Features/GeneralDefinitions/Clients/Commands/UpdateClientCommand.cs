using ERP.Application.Common.Interfaces.Services;

namespace ERP.Application.Features.GeneralDefinitions.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Result<GetClientDto>>
    {
        public int Id { get; set; }
        public UpdateClientDto _updateClientDTO { get; set; }
    }

    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Result<GetClientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public UpdateClientHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<GetClientDto>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Clients.GetEntityByIdWithIncludesAsync(request.Id,x=>x.Contacts,x=>x.PriceList);
            if (entity == null)
            {
                return Result<GetClientDto>.Failure("Client not found");
            }

            await SyncClientDataAsync(entity, request._updateClientDTO);

            var IsUpdated = await _unitOfWork.Clients.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetClientDto>();

                // Load the updated file paths for the response
                string folderName = "Clients\\S-" + entity.Id;
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
                    dto.FilePaths = fileAttachments;
                }
                return Result<GetClientDto>.Success(dto, "Client updated successfully");
            }

            return Result<GetClientDto>.Failure("Failed to update Client");
        }
        private async Task SyncClientDataAsync(Client entity, UpdateClientDto dto)
        {
            // 1. Identify missing items for Soft Delete
            var incomingContactIds = dto.Contacts.Select(c => c.Id).ToList();
            var contactsToDelete = entity.Contacts.Where(c => c.Id != 0 && !incomingContactIds.Contains(c.Id)).ToList();

            var incomingItemIds = dto.PriceList.Select(i => i.Id).ToList();
            var itemsToDelete = entity.PriceList.Where(i => i.Id != 0 && !incomingItemIds.Contains(i.Id)).ToList();

            // 2. Map updates and additions
            dto.Adapt(entity);
            entity.UpdatedBy = "SystemAudit";
            entity.UpdatedDate = DateTime.UtcNow;

            // 3. Execute Soft Deletes
            foreach (var contact in contactsToDelete) await _unitOfWork.ClientContacts.DeleteEntityAsync(contact.Id);
            foreach (var item in itemsToDelete) await _unitOfWork.ClientPriceLists.DeleteEntityAsync(item.Id);

            // 4. Handle File Sync
            if (dto.FilePaths != null)
            {
                string folderName = "Clients\\C-" + entity.Id;
                await _fileStorageService.DeleteFolderAsync(folderName);
                foreach (var file in dto.FilePaths)
                {
                    if (!string.IsNullOrEmpty(file.FilePath))
                        await _fileStorageService.UploadFileAsync(folderName, file.FilePath + "\\" + file.FileName);
                }

            }
        }
    }

    public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientDTO.FullName).NotEmpty().WithMessage("FullName is required");
            RuleFor(x => x._updateClientDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateClientDTO.Email)).WithMessage("Invalid email format");
        }
    }

}
