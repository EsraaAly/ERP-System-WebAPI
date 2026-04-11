namespace ERP.Application.Features.GeneralDefinitions.Cities.Queries.GetAllCities
{
    public class GetAllCitiesQuery : IRequest<Result<List<GetCityDto>>>
    {
    }

    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery, Result<List<GetCityDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetCityDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Cities.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetCityDto>>();

            return Result<List<GetCityDto>>.Success(dtos, "Cities retrieved successfully");
        }
    }
}
