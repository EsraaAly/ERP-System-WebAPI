namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class SupplierContactsController : BaseController
    {
        public SupplierContactsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.SupplierContacts.AddSupplierContact)]
        public async Task<IActionResult> CreateSupplierContact([FromBody] AddSupplierContactDto supplierContactDto)
        {
            var command = new AddSupplierContactCommand { _addSupplierContactDTO = supplierContactDto };
            return await HandleCommand<AddSupplierContactCommand, GetSupplierContactDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierContacts.GetSupplierContactById)]
        public async Task<IActionResult> GetSupplierContactById(int id)
        {
            var query = new GetSupplierContactByIdQuery { Id = id };
            return await HandleQueryWithData<GetSupplierContactByIdQuery, GetSupplierContactDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.SupplierContacts.GetAllSupplierContacts)]
        public async Task<IActionResult> GetAllSupplierContacts()
        {
            var query = new GetAllSupplierContactsQuery();
            return await HandleQueryWithData<GetAllSupplierContactsQuery, List<GetSupplierContactDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.SupplierContacts.UpdateSupplierContact)]
        public async Task<IActionResult> UpdateSupplierContact(int id, [FromBody] UpdateSupplierContactDto supplierContactDto)
        {

            var command = new UpdateSupplierContactCommand { _updateSupplierContactDTO = supplierContactDto };
            return await HandleCommand<UpdateSupplierContactCommand, GetSupplierContactDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.SupplierContacts.DeleteSupplierContact)]
        public async Task<IActionResult> DeleteSupplierContact(int id)
        {
            var command = new DeleteSupplierContactCommand { Id = id };
            return await HandleCommand<DeleteSupplierContactCommand, bool>(command);
        }
    }
}
