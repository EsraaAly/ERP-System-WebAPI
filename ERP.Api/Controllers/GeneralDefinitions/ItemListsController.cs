namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ItemListsController : BaseController
    {
        public ItemListsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ItemLists.AddItemList)]
        public async Task<IActionResult> CreateItemList([FromBody] AddItemListDto itemListDto)
        {
            var command = new AddItemListCommand { _addItemListDTO = itemListDto };
            return await HandleCommand<AddItemListCommand, GetItemListDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemLists.GetItemListById)]
        public async Task<IActionResult> GetItemListById(int id)
        {
            var query = new GetItemListByIdQuery { Id = id };
            return await HandleQueryWithData<GetItemListByIdQuery, GetItemListDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemLists.GetAllItemLists)]
        public async Task<IActionResult> GetAllItemLists()
        {
            var query = new GetAllItemListsQuery();
            return await HandleQueryWithData<GetAllItemListsQuery, List<GetItemListDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ItemLists.UpdateItemList)]
        public async Task<IActionResult> UpdateItemList(int id, [FromBody] UpdateItemListDto itemListDto)
        {
            if (id != itemListDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateItemListCommand { _updateItemListDTO = itemListDto };
            return await HandleCommand<UpdateItemListCommand, GetItemListDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ItemLists.DeleteItemList)]
        public async Task<IActionResult> DeleteItemList(int id)
        {
            var command = new DeleteItemListCommand { Id = id };
            return await HandleCommand<DeleteItemListCommand, bool>(command);
        }
    }
}
