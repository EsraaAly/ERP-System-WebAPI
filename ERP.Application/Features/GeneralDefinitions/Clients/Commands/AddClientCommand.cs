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
            var entity = request._addClientDTO.Adapt<Domain.Entities.GeneralDefinitions.Client>();

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
        private readonly IUnitOfWork _unitOfWork;

        public AddClientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            // Basic field validations
            RuleFor(x => x._addClientDTO.FullName)
                .NotEmpty().WithMessage("FullName is required")
                .MaximumLength(100).WithMessage("FullName cannot exceed 100 characters")
                .MinimumLength(2).WithMessage("FullName must be at least 2 characters");

            RuleFor(x => x._addClientDTO.FullNameAr)
                .NotEmpty().WithMessage("FullNameAr is required")
                .MaximumLength(100).WithMessage("FullNameAr cannot exceed 100 characters");

            RuleFor(x => x._addClientDTO.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x._addClientDTO.Email)).WithMessage("Invalid email format")
                .MaximumLength(255).WithMessage("Email cannot exceed 255 characters");

            RuleFor(x => x._addClientDTO.Tele)
                .NotEmpty().WithMessage("Tele is required")
                .Matches(@"^\+?[\d\s-()]{10,}$").WithMessage("Invalid phone number format")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters");

            RuleFor(x => x._addClientDTO.ReferenceNo)
                .NotEmpty().WithMessage("ReferenceNo is required")
                .Matches(@"^[A-Za-z0-9-]+$").WithMessage("Reference number can only contain letters, numbers, and hyphens")
                .MaximumLength(50).WithMessage("Reference number cannot exceed 50 characters");

            // Business logic validations
            RuleFor(x => x._addClientDTO.CashLimit)
                .GreaterThanOrEqualTo(0).WithMessage("Cash limit must be non-negative")
                .LessThan(decimal.MaxValue).WithMessage("Cash limit exceeds maximum allowed value");

            RuleFor(x => x._addClientDTO.ClientType)
                .NotEmpty().WithMessage("Client type is required")
                .MaximumLength(50).WithMessage("Client type cannot exceed 50 characters");

            RuleFor(x => x._addClientDTO.RegionId)
                .GreaterThan(0).WithMessage("Region is required");

            RuleFor(x => x._addClientDTO.CountryId)
                .GreaterThan(0).When(x => x._addClientDTO.CountryId.HasValue).WithMessage("Invalid Country");

            RuleFor(x => x._addClientDTO.CityId)
                .GreaterThan(0).When(x => x._addClientDTO.CityId.HasValue).WithMessage("Invalid City");

            RuleFor(x => x._addClientDTO.Supervisor)
                .NotEmpty().WithMessage("Supervisor is required")
                .MaximumLength(100).WithMessage("Supervisor name cannot exceed 100 characters");

            RuleFor(x => x._addClientDTO.Address)
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x._addClientDTO.Address));

            // Cross-field validations
            RuleFor(x => x._addClientDTO.PaymentTerms)
                .NotEmpty().WithMessage("Payment terms are required when cash limit exceeds 10000")
                .When(x => x._addClientDTO.CashLimit > 10000);

            RuleFor(x => x._addClientDTO.Supervisor)
                .NotEmpty().WithMessage("Supervisor is required for special clients")
                .When(x => x._addClientDTO.SpecialClient);

            RuleFor(x => x._addClientDTO.AccNo)
                .NotEmpty().WithMessage("Account number is required for special clients")
                .When(x => x._addClientDTO.SpecialClient);

            // Coordinates validation
            RuleFor(x => x._addClientDTO.Longitude)
                .Must(BeValidLongitude).When(x => !string.IsNullOrEmpty(x._addClientDTO.Longitude)).WithMessage("Invalid longitude format. Use decimal format like -122.4194");

            RuleFor(x => x._addClientDTO.Latitude)
                .Must(BeValidLatitude).When(x => !string.IsNullOrEmpty(x._addClientDTO.Latitude)).WithMessage("Invalid latitude format. Use decimal format like 37.7749");

            // Business logic uniqueness checks
            RuleFor(x => x._addClientDTO.Email)
                .MustAsync(BeUniqueEmail).When(x => !string.IsNullOrEmpty(x._addClientDTO.Email)).WithMessage("Email already exists");

            RuleFor(x => x._addClientDTO.ReferenceNo)
                .MustAsync(BeUniqueReferenceNo).When(x => !string.IsNullOrEmpty(x._addClientDTO.ReferenceNo)).WithMessage("Reference number already exists");

            RuleFor(x => x._addClientDTO.AccNo)
                .MustAsync(BeUniqueAccountNumber).When(x => !string.IsNullOrEmpty(x._addClientDTO.AccNo)).WithMessage("Account number already exists");
        }

        private bool BeValidLongitude(string longitude)
        {
            if (decimal.TryParse(longitude, out var lon))
            {
                return lon >= -180 && lon <= 180;
            }
            return false;
        }

        private bool BeValidLatitude(string latitude)
        {
            if (decimal.TryParse(latitude, out var lat))
            {
                return lat >= -90 && lat <= 90;
            }
            return false;
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var existingClient = await _unitOfWork.Clients.GetByExpressionAsync(c => c.Email == email && !c.IsDeleted);
            return existingClient == null;
        }

        private async Task<bool> BeUniqueReferenceNo(string referenceNo, CancellationToken cancellationToken)
        {
            var existingClient = await _unitOfWork.Clients.GetByExpressionAsync(c => c.ReferenceNo == referenceNo && !c.IsDeleted);
            return existingClient == null;
        }

        private async Task<bool> BeUniqueAccountNumber(string accNo, CancellationToken cancellationToken)
        {
            var existingClient = await _unitOfWork.Clients.GetByExpressionAsync(c => c.AccNo == accNo && !c.IsDeleted);
            return existingClient == null;
        }
    }
}
