namespace ERP.Application.Features.GeneralDefinitions.Cities.Commands.AddCity
{
    public class AddCityCommand : IRequest<Result<GetCityDto>>
    {
        public AddCityDto _addCityDTO { get; set; }
    }

    public class AddCityHandler : IRequestHandler<AddCityCommand, Result<GetCityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCityDto>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.City
            {
                CityName = request._addCityDTO.CityName,
                Country = request._addCityDTO.Country,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.Cities.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetCityDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetCityDto>.Success(dto, "City added successfully");
            }

            return Result<GetCityDto>.Failure("Failed to add City");
        }
    }

    public class AddCityValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityValidator()
        {
            RuleFor(x => x._addCityDTO.CityName).NotEmpty().WithMessage("CityName is required");
            RuleFor(x => x._addCityDTO.Country).NotEmpty().WithMessage("Country is required");
        }
    }
}
