namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ClientsController : BaseController
    {
        public ClientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Clients.AddClient)]
        public async Task<IActionResult> CreateClient([FromBody] AddClientDto clientDto)
        {
            var command = new AddClientCommand { _addClientDTO = clientDto };
            return await HandleCommand<AddClientCommand, GetClientDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Clients.GetClientById + "/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var query = new GetClientByIdQuery { Id = id };
            return await HandleQueryWithData<GetClientByIdQuery, GetClientDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Clients.GetAllClients)]
        public async Task<IActionResult> GetAllClients([FromQuery] GetAllClientsQuery query)
        {
            return await HandleQueryWithData<GetAllClientsQuery, List<GetClientDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Clients.UpdateClient +"/{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto clientDto)
        {

            var command = new UpdateClientCommand { _updateClientDTO = clientDto,Id=id };
            return await HandleCommand<UpdateClientCommand, GetClientDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Clients.DeleteClient + "/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var command = new DeleteClientCommand { Id = id };
            return await HandleCommand<DeleteClientCommand, bool>(command);
        }
    }
}
