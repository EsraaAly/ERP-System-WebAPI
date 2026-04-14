namespace ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.UpdateSupplierContact
{
    public class UpdateSupplierContactCommand : IRequest<Result<GetSupplierContactDto>>
    {
        public int Id { get; set; }
        public UpdateSupplierContactDto _updateSupplierContactDTO { get; set; }
    }

    public class UpdateSupplierContactHandler : IRequestHandler<UpdateSupplierContactCommand, Result<GetSupplierContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierContactDto>> Handle(UpdateSupplierContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierContacts.GetEntityByIdAsync(request.Id);

            if (entity == null)
            {
                return Result<GetSupplierContactDto>.Failure("SupplierContact not found");
            }

            entity.SupplierID = request._updateSupplierContactDTO.SupplierID;
            entity.Name = request._updateSupplierContactDTO.Name;
            entity.Position = request._updateSupplierContactDTO.Position;
            entity.Email = request._updateSupplierContactDTO.Email;
            entity.Phone = request._updateSupplierContactDTO.Phone;
            entity.Mobile = request._updateSupplierContactDTO.Mobile;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.SupplierContacts.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                var dto = entity.Adapt<GetSupplierContactDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierContactDto>.Success(dto, "SupplierContact updated successfully");
            }

            return Result<GetSupplierContactDto>.Failure("Failed to update SupplierContact");
        }
    }

    public class UpdateSupplierContactValidator : AbstractValidator<UpdateSupplierContactCommand>
    {
        public UpdateSupplierContactValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierContactDTO.SupplierID).GreaterThan(0).WithMessage("SupplierID is required");
            RuleFor(x => x._updateSupplierContactDTO.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x._updateSupplierContactDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateSupplierContactDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
