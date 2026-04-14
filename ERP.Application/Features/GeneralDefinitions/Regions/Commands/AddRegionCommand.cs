namespace ERP.Application.Features.GeneralDefinitions.Regions.Commands.AddRegion
{
    public class AddRegionCommand : IRequest<Result<GetRegionDto>>
    {
        public AddRegionDto _addRegionDTO { get; set; }
    }

    public class AddRegionHandler : IRequestHandler<AddRegionCommand, Result<GetRegionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetRegionDto>> Handle(AddRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addRegionDTO.Adapt<Domain.Entities.GeneralDefinitions.Region>();

            var addedEntity = await _unitOfWork.Regions.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetRegionDto>();
                return Result<GetRegionDto>.Success(dto, "Region added successfully");
            }

            return Result<GetRegionDto>.Failure("Failed to add Region");
        }
    }

    public class AddRegionValidator : AbstractValidator<AddRegionCommand>
    {
        public AddRegionValidator()
        {
            RuleFor(x => x._addRegionDTO.RegionName).NotEmpty().WithMessage("RegionName is required");
        }
    }
}
