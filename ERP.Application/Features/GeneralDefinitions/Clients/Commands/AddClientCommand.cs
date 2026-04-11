namespace ERP.Application.Features.GeneralDefinitions.Clients.Commands.AddClient
{
    public class AddClientCommand : IRequest<Result<GetClientDto>>
    {
        public AddClientDto _addClientDTO { get; set; }
    }

    public class AddClientHandler : IRequestHandler<AddClientCommand, Result<GetClientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientDto>> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.Client
            {
                FullName = request._addClientDTO.FullName,
                FullNameAr = request._addClientDTO.FullNameAr,
                ClientType = request._addClientDTO.ClientType,
                Supervisor = request._addClientDTO.Supervisor,
                Region = request._addClientDTO.Region,
                Tele = request._addClientDTO.Tele,
                ReferenceNo = request._addClientDTO.ReferenceNo,
                Email = request._addClientDTO.Email,
                Address = request._addClientDTO.Address,
                Longitude = request._addClientDTO.Longitude,
                Latitude = request._addClientDTO.Latitude,
                SpecialClient = request._addClientDTO.SpecialClient,
                CashLimit = request._addClientDTO.CashLimit,
                PaymentTerms = request._addClientDTO.PaymentTerms,
                Country = request._addClientDTO.Country,
                City = request._addClientDTO.City,
                AccNo = request._addClientDTO.AccNo,
                Status = request._addClientDTO.Status,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.Clients.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetClientDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientDto>.Success(dto, "Client added successfully");
            }

            return Result<GetClientDto>.Failure("Failed to add Client");
        }
    }

    public class AddClientValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientValidator()
        {
            RuleFor(x => x._addClientDTO.FullName).NotEmpty().WithMessage("FullName is required");
            RuleFor(x => x._addClientDTO.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x._addClientDTO.Email)).WithMessage("Invalid email format");
        }
    }
}
