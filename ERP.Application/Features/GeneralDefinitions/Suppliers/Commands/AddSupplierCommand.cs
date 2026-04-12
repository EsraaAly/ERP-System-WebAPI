namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.AddSupplier
{
    public class AddSupplierCommand : IRequest<Result<GetSupplierDto>>
    {
        public AddSupplierDto _addSupplierDTO { get; set; }
    }

    public class AddSupplierHandler : IRequestHandler<AddSupplierCommand, Result<GetSupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierDto>> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.Supplier
            {
                Name = request._addSupplierDTO.Name,
                NameAr = request._addSupplierDTO.NameAr,
                SupplierTypeId = request._addSupplierDTO.SupplierTypeId,
                CountryId = request._addSupplierDTO.CountryId,
                Telephone = request._addSupplierDTO.Telephone,
                Fax = request._addSupplierDTO.Fax,
                Email = request._addSupplierDTO.Email,
                Remarks = request._addSupplierDTO.Remarks,
                CR = request._addSupplierDTO.CR,
                VATNo = request._addSupplierDTO.VATNo,
                AccNo = request._addSupplierDTO.AccNo,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.Suppliers.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
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
            RuleFor(x => x._addSupplierDTO.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x._addSupplierDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addSupplierDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
