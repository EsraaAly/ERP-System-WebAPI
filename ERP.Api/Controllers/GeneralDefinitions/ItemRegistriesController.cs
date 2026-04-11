namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ItemRegistriesController : BaseController
    {
        public ItemRegistriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ItemRegistries.AddItemRegistry)]
        public async Task<IActionResult> CreateItemRegistry([FromBody] AddItemRegistryDto itemRegistryDto)
        {
            var command = new AddItemRegistryCommand { _addItemRegistryDTO = itemRegistryDto };
            return await HandleCommand<AddItemRegistryCommand, GetItemRegistryDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemRegistries.GetItemRegistryById)]
        public async Task<IActionResult> GetItemRegistryById(int id)
        {
            var query = new GetItemRegistryByIdQuery { Id = id };
            return await HandleQueryWithData<GetItemRegistryByIdQuery, GetItemRegistryDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemRegistries.GetAllItemRegistries)]
        public async Task<IActionResult> GetAllItemRegistries()
        {
            var query = new GetAllItemRegistriesQuery();
            return await HandleQueryWithData<GetAllItemRegistriesQuery, List<GetItemRegistryDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ItemRegistries.UpdateItemRegistry)]
        public async Task<IActionResult> UpdateItemRegistry(int id, [FromBody] UpdateItemRegistryDto itemRegistryDto)
        {
            if (id != itemRegistryDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateItemRegistryCommand { _updateItemRegistryDTO = itemRegistryDto };
            return await HandleCommand<UpdateItemRegistryCommand, GetItemRegistryDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ItemRegistries.DeleteItemRegistry)]
        public async Task<IActionResult> DeleteItemRegistry(int id)
        {
            var command = new DeleteItemRegistryCommand { Id = id };
            return await HandleCommand<DeleteItemRegistryCommand, bool>(command);
        }
    }
}
