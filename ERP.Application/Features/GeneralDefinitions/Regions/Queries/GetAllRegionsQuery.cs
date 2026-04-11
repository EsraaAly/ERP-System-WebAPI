namespace ERP.Application.Features.GeneralDefinitions.Regions.Queries.GetAllRegions
{
    public class GetAllRegionsQuery : IRequest<Result<List<GetRegionDto>>>
    {
    }

    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsQuery, Result<List<GetRegionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRegionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetRegionDto>>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Regions.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetRegionDto>>();

            return Result<List<GetRegionDto>>.Success(dtos, "Regions retrieved successfully");
        }
    }
}
