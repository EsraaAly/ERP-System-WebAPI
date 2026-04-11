namespace ERP.Application.Features.GeneralDefinitions.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Result<GetClientDto>>
    {
        public UpdateClientDto _updateClientDTO { get; set; }
    }

    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Result<GetClientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientDto>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Clients.GetEntityByIdAsync(request._updateClientDTO.Id);
            if (entity == null)
            {
                return Result<GetClientDto>.Failure("Client not found");
            }

            entity.FullName = request._updateClientDTO.FullName;
            entity.FullNameAr = request._updateClientDTO.FullNameAr;
            entity.ClientType = request._updateClientDTO.ClientType;
            entity.Supervisor = request._updateClientDTO.Supervisor;
            entity.Region = request._updateClientDTO.Region;
            entity.Tele = request._updateClientDTO.Tele;
            entity.ReferenceNo = request._updateClientDTO.ReferenceNo;
            entity.Email = request._updateClientDTO.Email;
            entity.Address = request._updateClientDTO.Address;
            entity.Longitude = request._updateClientDTO.Longitude;
            entity.Latitude = request._updateClientDTO.Latitude;
            entity.SpecialClient = request._updateClientDTO.SpecialClient;
            entity.CashLimit = request._updateClientDTO.CashLimit;
            entity.PaymentTerms = request._updateClientDTO.PaymentTerms;
            entity.Country = request._updateClientDTO.Country;
            entity.City = request._updateClientDTO.City;
            entity.AccNo = request._updateClientDTO.AccNo;
            entity.Status = request._updateClientDTO.Status;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.Clients.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetClientDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientDto>.Success(dto, "Client updated successfully");
            }

            return Result<GetClientDto>.Failure("Failed to update Client");
        }
    }

    public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x._updateClientDTO.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientDTO.FullName).NotEmpty().WithMessage("FullName is required");
            RuleFor(x => x._updateClientDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._updateClientDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
