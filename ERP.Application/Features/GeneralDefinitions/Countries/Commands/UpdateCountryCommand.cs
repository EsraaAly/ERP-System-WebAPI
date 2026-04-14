namespace ERP.Application.Features.GeneralDefinitions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<Result<GetCountryDto>>
    {
        public int Id { get; set; }
        public UpdateCountryDto _updateCountryDTO { get; set; }
    }

    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, Result<GetCountryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCountryDto>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Countries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetCountryDto>.Failure("Country not found");
            }

            entity.CountryName = request._updateCountryDTO.CountryName;
            entity.CountryCode = request._updateCountryDTO.CountryCode;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.Countries.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetCountryDto>();

                return Result<GetCountryDto>.Success(dto, "Country updated successfully");
            }

            return Result<GetCountryDto>.Failure("Failed to update Country");
        }
    }

    public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateCountryDTO.CountryName).NotEmpty().WithMessage("CountryName is required");
            RuleFor(x => x._updateCountryDTO.CountryCode).NotEmpty().WithMessage("CountryCode is required");
        }
    }
}
