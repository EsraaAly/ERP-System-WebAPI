namespace ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.AddSupplierContact
{
    public class AddSupplierContactCommand : IRequest<Result<GetSupplierContactDto>>
    {
        public AddSupplierContactDto _addSupplierContactDTO { get; set; }
    }

    public class AddSupplierContactHandler : IRequestHandler<AddSupplierContactCommand, Result<GetSupplierContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSupplierContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierContactDto>> Handle(AddSupplierContactCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.SupplierContact
            {
                SupplierID = request._addSupplierContactDTO.SupplierID,
                Name = request._addSupplierContactDTO.Name,
                Position = request._addSupplierContactDTO.Position,
                Email = request._addSupplierContactDTO.Email,
                Phone = request._addSupplierContactDTO.Phone,
                Mobile = request._addSupplierContactDTO.Mobile,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.SupplierContacts.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetSupplierContactDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierContactDto>.Success(dto, "SupplierContact added successfully");
            }

            return Result<GetSupplierContactDto>.Failure("Failed to add SupplierContact");
        }
    }

    public class AddSupplierContactValidator : AbstractValidator<AddSupplierContactCommand>
    {
        public AddSupplierContactValidator()
        {
            RuleFor(x => x._addSupplierContactDTO.SupplierID).GreaterThan(0).WithMessage("SupplierID is required");
            RuleFor(x => x._addSupplierContactDTO.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x._addSupplierContactDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addSupplierContactDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
