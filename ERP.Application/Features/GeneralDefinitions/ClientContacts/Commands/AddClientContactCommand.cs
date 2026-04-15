namespace ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.AddClientContact
{
    public class AddClientContactCommand : IRequest<Result<GetClientContactDto>>
    {
        public AddClientContactDto _addClientContactDTO { get; set; }
    }

    public class AddClientContactHandler : IRequestHandler<AddClientContactCommand, Result<GetClientContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClientContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientContactDto>> Handle(AddClientContactCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addClientContactDTO.Adapt<Domain.Entities.GeneralDefinitions.ClientContact>();

            var addedEntity = await _unitOfWork.ClientContacts.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetClientContactDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientContactDto>.Success(dto, "ClientContact added successfully");
            }

            return Result<GetClientContactDto>.Failure("Failed to add ClientContact");
        }
    }

    public class AddClientContactValidator : AbstractValidator<AddClientContactCommand>
    {
        public AddClientContactValidator()
        {
            RuleFor(x => x._addClientContactDTO.ClientId).GreaterThan(0).WithMessage("ClientId is required");
            RuleFor(x => x._addClientContactDTO.ContactName).NotEmpty().WithMessage("ContactName is required");
            RuleFor(x => x._addClientContactDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addClientContactDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
