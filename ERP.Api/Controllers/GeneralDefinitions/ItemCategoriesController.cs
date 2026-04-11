namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ItemCategoriesController : BaseController
    {
        public ItemCategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ItemCategories.AddItemCategory)]
        public async Task<IActionResult> CreateItemCategory([FromBody] AddItemCategoryDto itemCategoryDto)
        {
            var command = new AddItemCategoryCommand { _addItemCategoryDTO = itemCategoryDto };
            return await HandleCommand<AddItemCategoryCommand, GetItemCategoryDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemCategories.GetItemCategoryById)]
        public async Task<IActionResult> GetItemCategoryById(int id)
        {
            var query = new GetItemCategoryByIdQuery { Id = id };
            return await HandleQueryWithData<GetItemCategoryByIdQuery, GetItemCategoryDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ItemCategories.GetAllItemCategories)]
        public async Task<IActionResult> GetAllItemCategories()
        {
            var query = new GetAllItemCategoriesQuery();
            return await HandleQueryWithData<GetAllItemCategoriesQuery, List<GetItemCategoryDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ItemCategories.UpdateItemCategory)]
        public async Task<IActionResult> UpdateItemCategory(int id, [FromBody] UpdateItemCategoryDto itemCategoryDto)
        {
            if (id != itemCategoryDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateItemCategoryCommand { _updateItemCategoryDTO = itemCategoryDto };
            return await HandleCommand<UpdateItemCategoryCommand, GetItemCategoryDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ItemCategories.DeleteItemCategory)]
        public async Task<IActionResult> DeleteItemCategory(int id)
        {
            var command = new DeleteItemCategoryCommand { Id = id };
            return await HandleCommand<DeleteItemCategoryCommand, bool>(command);
        }
    }
}
