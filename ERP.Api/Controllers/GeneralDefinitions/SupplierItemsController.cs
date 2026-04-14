namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class SupplierItemsController : BaseController
    {
        public SupplierItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.SupplierItems.AddSupplierItem)]
        public async Task<IActionResult> CreateSupplierItem([FromBody] AddSupplierItemDto supplierItemDto)
        {
            var command = new AddSupplierItemCommand { _addSupplierItemDTO = supplierItemDto };
            return await HandleCommand<AddSupplierItemCommand, GetSupplierItemDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierItems.GetSupplierItemById + "/{id}")]
        public async Task<IActionResult> GetSupplierItemById(int id)
        {
            var query = new GetSupplierItemByIdQuery { Id = id };
            return await HandleQueryWithData<GetSupplierItemByIdQuery, GetSupplierItemDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierItems.GetAllSupplierItems)]
        public async Task<IActionResult> GetAllSupplierItems()
        {
            var query = new GetAllSupplierItemsQuery();
            return await HandleQueryWithData<GetAllSupplierItemsQuery, List<GetSupplierItemDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.SupplierItems.UpdateSupplierItem+"/{id}")]
        public async Task<IActionResult> UpdateSupplierItem(int id, [FromBody] UpdateSupplierItemDto supplierItemDto)
        {

            var command = new UpdateSupplierItemCommand { _updateSupplierItemDTO = supplierItemDto,Id=id };
            return await HandleCommand<UpdateSupplierItemCommand, GetSupplierItemDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.SupplierItems.DeleteSupplierItem + "/{id}")]
        public async Task<IActionResult> DeleteSupplierItem(int id)
        {
            var command = new DeleteSupplierItemCommand { Id = id };
            return await HandleCommand<DeleteSupplierItemCommand, bool>(command);
        }
    }
}
