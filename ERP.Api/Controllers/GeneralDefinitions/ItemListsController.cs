using ERP.Application.Features.GeneralDefinitions.ItemLists.Queries;

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

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemLists.GetItemListById + "/{id}")]
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

        [HttpPut(ApiRoutes.GeneralDefinitions.ItemLists.UpdateItemList + "/{id}")]
        public async Task<IActionResult> UpdateItemList(int id, [FromBody] UpdateItemListDto itemListDto)
        {

            var command = new UpdateItemListCommand { _updateItemListDTO = itemListDto,Id=id };
            return await HandleCommand<UpdateItemListCommand, GetItemListDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ItemLists.DeleteItemList + "/{id}")]
        public async Task<IActionResult> DeleteItemList(int id)
        {
            var command = new DeleteItemListCommand { Id = id };
            return await HandleCommand<DeleteItemListCommand, bool>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemLists.GetItemListsByCategoryId + "/{id}")]
        public async Task<IActionResult> GetItemListByCategoryId(int id)
        {
            var query = new GetItemListByCategoryIdQuery { Id = id };
            return await HandleQueryWithData<GetItemListByCategoryIdQuery, List<GetItemListDto>>(query);
        }
    }
}
