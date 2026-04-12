namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class CitiesController : BaseController
    {
        public CitiesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Cities.AddCity)]
        public async Task<IActionResult> CreateCity([FromBody] AddCityDto cityDto)
        {
            var command = new AddCityCommand { _addCityDTO = cityDto };
            return await HandleCommand<AddCityCommand, GetCityDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Cities.GetCityById + "/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var query = new GetCityByIdQuery { Id = id };
            return await HandleQueryWithData<GetCityByIdQuery, GetCityDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Cities.GetAllCities)]
        public async Task<IActionResult> GetAllCities()
        {
            var query = new GetAllCitiesQuery();
            return await HandleQueryWithData<GetAllCitiesQuery, List<GetCityDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Cities.UpdateCity + "/{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityDto cityDto)
        {
            var command = new UpdateCityCommand { _updateCityDTO = cityDto,id = id };
            return await HandleCommand<UpdateCityCommand, GetCityDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Cities.DeleteCity + "/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var command = new DeleteCityCommand { Id = id };
            return await HandleCommand<DeleteCityCommand, bool>(command);
        }
    }
}
