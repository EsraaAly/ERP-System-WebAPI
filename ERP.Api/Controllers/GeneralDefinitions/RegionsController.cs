namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class RegionsController : BaseController
    {
        public RegionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Regions.AddRegion)]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto regionDto)
        {
            var command = new AddRegionCommand { _addRegionDTO = regionDto };
            return await HandleCommand<AddRegionCommand, GetRegionDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Regions.GetRegionById + "/{id}")]
        public async Task<IActionResult> GetRegionById(int id)
        {
            var query = new GetRegionByIdQuery { Id = id };
            return await HandleQueryWithData<GetRegionByIdQuery, GetRegionDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Regions.GetAllRegions)]
        public async Task<IActionResult> GetAllRegions()
        {
            var query = new GetAllRegionsQuery();
            return await HandleQueryWithData<GetAllRegionsQuery, List<GetRegionDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Regions.UpdateRegion + "/{id}")]
        public async Task<IActionResult> UpdateRegion(int id, [FromBody] UpdateRegionDto regionDto)
        {

            var command = new UpdateRegionCommand { _updateRegionDTO = regionDto,Id=id };
            return await HandleCommand<UpdateRegionCommand, GetRegionDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Regions.DeleteRegion + "/{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var command = new DeleteRegionCommand { Id = id };
            return await HandleCommand<DeleteRegionCommand, bool>(command);
        }
    }
}
