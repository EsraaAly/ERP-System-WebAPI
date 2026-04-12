namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class StoresController : BaseController
    {
        public StoresController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Stores.AddStore)]
        public async Task<IActionResult> CreateStore([FromBody] AddStoreDto storeDto)
        {
            var command = new AddStoreCommand { _addStoreDTO = storeDto };
            return await HandleCommand<AddStoreCommand, GetStoreDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Stores.GetStoreById + "/{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var query = new GetStoreByIdQuery { Id = id };
            return await HandleQueryWithData<GetStoreByIdQuery, GetStoreDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Stores.GetAllStores)]
        public async Task<IActionResult> GetAllStores()
        {
            var query = new GetAllStoresQuery();
            return await HandleQueryWithData<GetAllStoresQuery, List<GetStoreDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Stores.UpdateStore + "/{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] UpdateStoreDto storeDto)
        {
            var command = new UpdateStoreCommand { _updateStoreDTO = storeDto, Id = id };
            return await HandleCommand<UpdateStoreCommand, GetStoreDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Stores.DeleteStore + "/{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var command = new DeleteStoreCommand { Id = id };
            return await HandleCommand<DeleteStoreCommand, bool>(command);
        }
    }
}
