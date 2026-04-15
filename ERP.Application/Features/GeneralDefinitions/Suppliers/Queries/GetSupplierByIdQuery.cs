using ERP.Application.Common.Interfaces.Services;
namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<Result<GetSupplierDto>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, Result<GetSupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;

        public GetSupplierByIdHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<GetSupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdWithIncludesAsync(request.Id, x => x.Contacts, x => x.Items);
            if (entity == null)
            {
                return Result<GetSupplierDto>.Failure("Supplier not found");
            }

            var dto = entity.Adapt<GetSupplierDto>();

            // Load files
            string folderName = "S-" + entity.Id;
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

            return Result<GetSupplierDto>.Success(dto, "Supplier retrieved successfully");
        }
    }

    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
