namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class SuppliersController : BaseController
    {
        public SuppliersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Suppliers.AddSupplier)]
        public async Task<IActionResult> CreateSupplier([FromBody] AddSupplierDto supplierDto)
        {
            var command = new AddSupplierCommand { _addSupplierDTO = supplierDto };
            return await HandleCommand<AddSupplierCommand, GetSupplierDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Suppliers.GetSupplierById)]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var query = new GetSupplierByIdQuery { Id = id };
            return await HandleQueryWithData<GetSupplierByIdQuery, GetSupplierDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Suppliers.GetAllSuppliers)]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var query = new GetAllSuppliersQuery();
            return await HandleQueryWithData<GetAllSuppliersQuery, List<GetSupplierDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Suppliers.UpdateSupplier)]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] UpdateSupplierDto supplierDto)
        {
            if (id != supplierDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateSupplierCommand { _updateSupplierDTO = supplierDto };
            return await HandleCommand<UpdateSupplierCommand, GetSupplierDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Suppliers.DeleteSupplier)]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var command = new DeleteSupplierCommand { Id = id };
            return await HandleCommand<DeleteSupplierCommand, bool>(command);
        }
    }
}
