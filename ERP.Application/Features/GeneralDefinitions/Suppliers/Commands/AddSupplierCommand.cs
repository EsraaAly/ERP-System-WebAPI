 using ERP.Application.Common.Interfaces.Services;

namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.AddSupplier
{
    public class AddSupplierCommand : IRequest<Result<GetSupplierDto>>
    {
        public AddSupplierDto _addSupplierDTO { get; set; }
    }

    public class AddSupplierHandler : IRequestHandler<AddSupplierCommand, Result<GetSupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public AddSupplierHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<GetSupplierDto>> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addSupplierDTO.Adapt<Domain.Entities.GeneralDefinitions.Supplier>();

            entity.Items.ForEach(i => i.SupplierId = 0);
            entity.Contacts.ForEach(c => c.SupplierId = 0);

            var addedEntity = await _unitOfWork.Suppliers.AddEntityAsync(entity);

            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();

                // Handle file uploads
                if (request._addSupplierDTO.FilePaths != null && request._addSupplierDTO.FilePaths.Any())
                {
                    // Create folder name like Supplier-123
                    string folderName = "S-" + addedEntity.Id;

                    foreach (var file in request._addSupplierDTO.FilePaths)
                    {
                        if (!string.IsNullOrEmpty(file.FilePath))
                        {
                            await _fileStorageService.UploadFileAsync(folderName, file.FilePath);
                        }
                    }
                }

                var dto = addedEntity.Adapt<GetSupplierDto>();
                return Result<GetSupplierDto>.Success(dto, "Supplier added successfully");
            }

            return Result<GetSupplierDto>.Failure("Failed to add Supplier");
        }
    }

    public class AddSupplierValidator : AbstractValidator<AddSupplierCommand>
    {
        public AddSupplierValidator()
        {
            RuleFor(x => x._addSupplierDTO).NotNull().WithMessage("Supplier data is required");
            
            When(x => x._addSupplierDTO != null, () =>
            {
                RuleFor(x => x._addSupplierDTO.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x._addSupplierDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addSupplierDTO.Email)).WithMessage("Invalid email format");
            });
        }
    }
}
