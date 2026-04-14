namespace ERP.Application.Features.GeneralDefinitions.Regions.Commands.UpdateRegion
{
    public class UpdateRegionCommand : IRequest<Result<GetRegionDto>>
    {
        public int Id { get; set; }
        public UpdateRegionDto _updateRegionDTO { get; set; }
    }

    public class UpdateRegionHandler : IRequestHandler<UpdateRegionCommand, Result<GetRegionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetRegionDto>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Regions.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetRegionDto>.Failure("Region not found");
            }

            entity.RegionName = request._updateRegionDTO.RegionName;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.Regions.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetRegionDto>();
                return Result<GetRegionDto>.Success(dto, "Region updated successfully");
            }

            return Result<GetRegionDto>.Failure("Failed to update Region");
        }
    }

    public class UpdateRegionValidator : AbstractValidator<UpdateRegionCommand>
    {
        public UpdateRegionValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateRegionDTO.RegionName).NotEmpty().WithMessage("RegionName is required");
        }
    }
}
