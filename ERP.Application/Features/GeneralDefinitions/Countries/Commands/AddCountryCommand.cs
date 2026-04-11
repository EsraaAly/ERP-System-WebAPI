namespace ERP.Application.Features.GeneralDefinitions.Countries.Commands.AddCountry
{
    public class AddCountryCommand : IRequest<Result<GetCountryDto>>
    {
        public AddCountryDto _addCountryDTO { get; set; }
    }

    public class AddCountryHandler : IRequestHandler<AddCountryCommand, Result<GetCountryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCountryDto>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.Country
            {
                CountryName = request._addCountryDTO.CountryName,
                CountryCode = request._addCountryDTO.CountryCode,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.Countries.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetCountryDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetCountryDto>.Success(dto, "Country added successfully");
            }

            return Result<GetCountryDto>.Failure("Failed to add Country");
        }
    }

    public class AddCountryValidator : AbstractValidator<AddCountryCommand>
    {
        public AddCountryValidator()
        {
            RuleFor(x => x._addCountryDTO.CountryName).NotEmpty().WithMessage("CountryName is required");
            RuleFor(x => x._addCountryDTO.CountryCode).NotEmpty().WithMessage("CountryCode is required");
        }
    }
}
