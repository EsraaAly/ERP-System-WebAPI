namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class StoreCategoriesController : BaseController
    {
        public StoreCategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.StoreCategories.AddStoreCategory)]
        public async Task<IActionResult> CreateStoreCategory([FromBody] AddStoreCategoryDto storeCategoryDto)
        {
            var command = new AddStoreCategoryCommand { _addStoreCategoryDTO = storeCategoryDto };
            return await HandleCommand<AddStoreCategoryCommand, GetStoreCategoryDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.StoreCategories.GetStoreCategoryById + "/{id}")]
        public async Task<IActionResult> GetStoreCategoryById(int id)
        {
            var query = new GetStoreCategoryByIdQuery { Id = id };
            return await HandleQueryWithData<GetStoreCategoryByIdQuery, GetStoreCategoryDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.StoreCategories.GetAllStoreCategories)]
        public async Task<IActionResult> GetAllStoreCategories()
        {
            var query = new GetAllStoreCategoriesQuery();
            return await HandleQueryWithData<GetAllStoreCategoriesQuery, List<GetStoreCategoryDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.StoreCategories.UpdateStoreCategory + "/{id}")]
        public async Task<IActionResult> UpdateStoreCategory(int id, [FromBody] UpdateStoreCategoryDto storeCategoryDto)
        {
            var command = new UpdateStoreCategoryCommand { _updateStoreCategoryDTO = storeCategoryDto, Id = id };
            return await HandleCommand<UpdateStoreCategoryCommand, GetStoreCategoryDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.StoreCategories.DeleteStoreCategory + "/{id}")]
        public async Task<IActionResult> DeleteStoreCategory(int id)
        {
            var command = new DeleteStoreCategoryCommand { Id = id };
            return await HandleCommand<DeleteStoreCategoryCommand, bool>(command);
        }
    }
}
