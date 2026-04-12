namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class CountriesController : BaseController
    {
        public CountriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Countries.AddCountry)]
        public async Task<IActionResult> CreateCountry([FromBody] AddCountryDto countryDto)
        {
            var command = new AddCountryCommand { _addCountryDTO = countryDto };
            return await HandleCommand<AddCountryCommand, GetCountryDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Countries.GetCountryById + "/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var query = new GetCountryByIdQuery { Id = id };
            return await HandleQueryWithData<GetCountryByIdQuery, GetCountryDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Countries.GetAllCountries)]
        public async Task<IActionResult> GetAllCountries()
        {
            var query = new GetAllCountriesQuery();
            return await HandleQueryWithData<GetAllCountriesQuery, List<GetCountryDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Countries.UpdateCountry + "/{id}")]
        public async Task<IActionResult> UpdateCountry(int id,[FromBody] UpdateCountryDto countryDto)
        {

            var command = new UpdateCountryCommand { _updateCountryDTO = countryDto,Id = id };
            return await HandleCommand<UpdateCountryCommand, GetCountryDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Countries.DeleteCountry + "/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var command = new DeleteCountryCommand { Id = id };
            return await HandleCommand<DeleteCountryCommand, bool>(command);
        }
    }
}
