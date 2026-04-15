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
            var entity = request._addSupplierContactDTO.Adapt<Domain.Entities.GeneralDefinitions.SupplierContact>();

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
            RuleFor(x => x._addSupplierContactDTO.SupplierId).GreaterThan(0).WithMessage("SupplierId is required");
            RuleFor(x => x._addSupplierContactDTO.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x._addSupplierContactDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addSupplierContactDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
