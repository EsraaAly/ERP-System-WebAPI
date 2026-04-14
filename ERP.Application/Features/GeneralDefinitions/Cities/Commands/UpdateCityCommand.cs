namespace ERP.Application.Features.GeneralDefinitions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<Result<GetCityDto>>
    {
        public int id { get; set; }
        public UpdateCityDto _updateCityDTO { get; set; }
    }

    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Result<GetCityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCityDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Cities.GetEntityByIdAsync(request.id);
            if (entity == null)
            {
                return Result<GetCityDto>.Failure("City not found");
            }

            entity.CityName = request._updateCityDTO.CityName;
            entity.Country = request._updateCityDTO.Country;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.Cities.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetCityDto>();
                return Result<GetCityDto>.Success(dto, "City updated successfully");
            }

            return Result<GetCityDto>.Failure("Failed to update City");
        }
    }

    public class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateCityDTO.CityName).NotEmpty().WithMessage("CityName is required");
            RuleFor(x => x._updateCityDTO.Country).NotEmpty().WithMessage("Country is required");
        }
    }
}
