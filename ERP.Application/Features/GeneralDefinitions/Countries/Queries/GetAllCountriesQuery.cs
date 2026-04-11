namespace ERP.Application.Features.GeneralDefinitions.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<Result<List<GetCountryDto>>>
    {
    }

    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, Result<List<GetCountryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCountriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetCountryDto>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Countries.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetCountryDto>>();

            return Result<List<GetCountryDto>>.Success(dtos, "Countries retrieved successfully");
        }
    }
}
