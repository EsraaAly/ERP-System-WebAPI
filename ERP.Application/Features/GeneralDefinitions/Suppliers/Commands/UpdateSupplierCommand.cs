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

        public UpdateSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierDto>.Failure("Supplier not found");
            }

            entity.Name = request._updateSupplierDTO.Name;
            entity.NameAr = request._updateSupplierDTO.NameAr;
            entity.SupplierTypeId = request._updateSupplierDTO.SupplierTypeId;
            entity.CountryId = request._updateSupplierDTO.CountryId;
            entity.Telephone = request._updateSupplierDTO.Telephone;
            entity.Fax = request._updateSupplierDTO.Fax;
            entity.Email = request._updateSupplierDTO.Email;
            entity.Remarks = request._updateSupplierDTO.Remarks;
            entity.CR = request._updateSupplierDTO.CR;
            entity.VATNo = request._updateSupplierDTO.VATNo;
            entity.AccNo = request._updateSupplierDTO.AccNo;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.Suppliers.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetSupplierDto>();
                return Result<GetSupplierDto>.Success(dto, "Supplier updated successfully");
            }

            return Result<GetSupplierDto>.Failure("Failed to update Supplier");
        }
    }

    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierDTO.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x._updateSupplierDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateSupplierDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
