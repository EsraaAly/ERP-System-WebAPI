namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ClientContactsController : BaseController
    {
        public ClientContactsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ClientContacts.AddClientContact)]
        public async Task<IActionResult> CreateClientContact([FromBody] AddClientContactDto clientContactDto)
        {
            var command = new AddClientContactCommand { _addClientContactDTO  = clientContactDto };
            return await HandleCommand<AddClientContactCommand, GetClientContactDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientContacts.GetClientContactById)]
        public async Task<IActionResult> GetClientContactById(int id)
        {
            var query = new GetClientContactByIdQuery { Id = id };
            return await HandleQueryWithData<GetClientContactByIdQuery, GetClientContactDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientContacts.GetAllClientContacts)]
        public async Task<IActionResult> GetAllClientContacts()
        {
            var query = new GetAllClientContactsQuery();
            return await HandleQueryWithData<GetAllClientContactsQuery, List<GetClientContactDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ClientContacts.UpdateClientContact)]
        public async Task<IActionResult> UpdateClientContact(int id, [FromBody] UpdateClientContactDto clientContactDto)
        {
            if (id != clientContactDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateClientContactCommand { _updateClientContactDTO = clientContactDto };
            return await HandleCommand<UpdateClientContactCommand, GetClientContactDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ClientContacts.DeleteClientContact)]
        public async Task<IActionResult> DeleteClientContact(int id)
        {
            var command = new DeleteClientContactCommand { Id = id };
            return await HandleCommand<DeleteClientContactCommand, bool>(command);
        }
    }
}
