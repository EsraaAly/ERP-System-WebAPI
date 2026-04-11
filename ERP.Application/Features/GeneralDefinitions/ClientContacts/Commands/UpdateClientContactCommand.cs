namespace ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.UpdateClientContact
{
    public class UpdateClientContactCommand : IRequest<Result<GetClientContactDto>>
    {
        public UpdateClientContactDto _updateClientContactDTO { get; set; }
    }

    public class UpdateClientContactHandler : IRequestHandler<UpdateClientContactCommand, Result<GetClientContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientContactDto>> Handle(UpdateClientContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientContacts.GetEntityByIdAsync(request._updateClientContactDTO.Id);
            if (entity == null)
            {
                return Result<GetClientContactDto>.Failure("ClientContact not found");
            }

            entity.ClientID = request._updateClientContactDTO.ClientID;
            entity.ContactName = request._updateClientContactDTO.ContactName;
            entity.Position = request._updateClientContactDTO.Position;
            entity.Mobile = request._updateClientContactDTO.Mobile;
            entity.Email = request._updateClientContactDTO.Email;
            entity.Tele = request._updateClientContactDTO.Tele;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.ClientContacts.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetClientContactDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientContactDto>.Success(dto, "ClientContact updated successfully");
            }

            return Result<GetClientContactDto>.Failure("Failed to update ClientContact");
        }
    }

    public class UpdateClientContactValidator : AbstractValidator<UpdateClientContactCommand>
    {
        public UpdateClientContactValidator()
        {
            RuleFor(x => x._updateClientContactDTO.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientContactDTO.ClientID).GreaterThan(0).WithMessage("ClientID is required");
            RuleFor(x => x._updateClientContactDTO.ContactName).NotEmpty().WithMessage("ContactName is required");
            RuleFor(x => x._updateClientContactDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateClientContactDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
