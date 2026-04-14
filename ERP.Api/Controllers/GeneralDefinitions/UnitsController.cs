namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class UnitsController : BaseController
    {
        public UnitsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Units.AddUnit)]
        public async Task<IActionResult> CreateUnit([FromBody] AddUnitDto unitDto)
        {
            var command = new AddUnitCommand { _addUnitDTO = unitDto };
            return await HandleCommand<AddUnitCommand, GetUnitDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Units.GetUnitById + "/{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var query = new GetUnitByIdQuery { Id = id };
            return await HandleQueryWithData<GetUnitByIdQuery, GetUnitDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Units.GetAllUnits)]
        public async Task<IActionResult> GetAllUnits()
        {
            var query = new GetAllUnitsQuery();
            return await HandleQueryWithData<GetAllUnitsQuery, List<GetUnitDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Units.UpdateUnit + "/{id}")]
        public async Task<IActionResult> UpdateUnit(int id, [FromBody] UpdateUnitDto unitDto)
        {

            var command = new UpdateUnitCommand { _updateUnitDTO = unitDto ,Id = id};
            return await HandleCommand<UpdateUnitCommand, GetUnitDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Units.DeleteUnit + "/{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var command = new DeleteUnitCommand { Id = id };
            return await HandleCommand<DeleteUnitCommand, bool>(command);
        }
    }
}
