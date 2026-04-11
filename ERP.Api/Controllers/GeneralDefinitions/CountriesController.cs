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

        [HttpGet(ApiRoutes.GeneralDefinitions.Countries.GetCountryById)]
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

        [HttpPut(ApiRoutes.GeneralDefinitions.Countries.UpdateCountry)]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDto countryDto)
        {
            if (id != countryDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateCountryCommand { _updateCountryDTO = countryDto };
            return await HandleCommand<UpdateCountryCommand, GetCountryDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Countries.DeleteCountry)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var command = new DeleteCountryCommand { Id = id };
            return await HandleCommand<DeleteCountryCommand, bool>(command);
        }
    }
}
