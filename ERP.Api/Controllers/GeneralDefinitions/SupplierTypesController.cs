namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class SupplierTypesController : BaseController
    {
        public SupplierTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.SupplierTypes.AddSupplierType)]
        public async Task<IActionResult> CreateSupplierType([FromBody] AddSupplierTypeDto supplierTypeDto)
        {
            var command = new AddSupplierTypeCommand { _addSupplierTypeDTO = supplierTypeDto };
            return await HandleCommand<AddSupplierTypeCommand, GetSupplierTypeDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierTypes.GetSupplierTypeById + "/{id}")]
        public async Task<IActionResult> GetSupplierTypeById(int id)
        {
            var query = new GetSupplierTypeByIdQuery { Id = id };
            return await HandleQueryWithData<GetSupplierTypeByIdQuery, GetSupplierTypeDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierTypes.GetAllSupplierTypes)]
        public async Task<IActionResult> GetAllSupplierTypes()
        {
            var query = new GetAllSupplierTypesQuery();
            return await HandleQueryWithData<GetAllSupplierTypesQuery, List<GetSupplierTypeDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.SupplierTypes.UpdateSupplierType + "/{id}")]
        public async Task<IActionResult> UpdateSupplierType(int id, [FromBody] UpdateSupplierTypeDto supplierTypeDto)
        {

            var command = new UpdateSupplierTypeCommand { _updateSupplierTypeDTO = supplierTypeDto, Id = id };
            return await HandleCommand<UpdateSupplierTypeCommand, GetSupplierTypeDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.SupplierTypes.DeleteSupplierType + "/{id}")]
        public async Task<IActionResult> DeleteSupplierType(int id)
        {
            var command = new DeleteSupplierTypeCommand { Id = id };
            return await HandleCommand<DeleteSupplierTypeCommand, bool>(command);
        }
    }
}
