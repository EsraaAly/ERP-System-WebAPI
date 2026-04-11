namespace ERP.Application.Features.GeneralDefinitions.Units.Queries.GetAllUnits
{
    public class GetAllUnitsQuery : IRequest<Result<List<GetUnitDto>>>
    {
    }

    public class GetAllUnitsHandler : IRequestHandler<GetAllUnitsQuery, Result<List<GetUnitDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUnitsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetUnitDto>>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Unit.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetUnitDto>>();

            return Result<List<GetUnitDto>>.Success(dtos, "Units retrieved successfully");
        }
    }
}
