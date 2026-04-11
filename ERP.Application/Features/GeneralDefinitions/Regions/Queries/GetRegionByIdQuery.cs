namespace ERP.Application.Features.GeneralDefinitions.Regions.Queries.GetRegionById
{
    public class GetRegionByIdQuery : IRequest<Result<GetRegionDto>>
    {
        public int Id { get; set; }
    }

    public class GetRegionByIdHandler : IRequestHandler<GetRegionByIdQuery, Result<GetRegionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRegionByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetRegionDto>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Regions.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetRegionDto>.Failure("Region not found");
            }

            var dto = entity.Adapt<GetRegionDto>();

            return Result<GetRegionDto>.Success(dto, "Region retrieved successfully");
        }
    }

    public class GetRegionByIdValidator : AbstractValidator<GetRegionByIdQuery>
    {
        public GetRegionByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
