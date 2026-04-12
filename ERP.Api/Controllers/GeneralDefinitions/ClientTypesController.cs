namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ClientTypesController : BaseController
    {
        public ClientTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ClientTypes.AddClientType)]
        public async Task<IActionResult> CreateClientType([FromBody] AddClientTypeDto clientTypeDto)
        {
            var command = new AddClientTypeCommand { _addClientTypeDTO = clientTypeDto };
            return await HandleCommand<AddClientTypeCommand, GetClientTypeDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientTypes.GetClientTypeById + "/{id}")]
        public async Task<IActionResult> GetClientTypeById(int id)
        {
            var query = new GetClientTypeByIdQuery { Id = id };
            return await HandleQueryWithData<GetClientTypeByIdQuery, GetClientTypeDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientTypes.GetAllClientTypes)]
        public async Task<IActionResult> GetAllClientTypes()
        {
            var query = new GetAllClientTypesQuery();
            return await HandleQueryWithData<GetAllClientTypesQuery, List<GetClientTypeDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ClientTypes.UpdateClientType + "/{id}")]
        public async Task<IActionResult> UpdateClientType(int id, [FromBody] UpdateClientTypeDto clientTypeDto)
        {
 
            var command = new UpdateClientTypeCommand { _updateClientTypeDTO = clientTypeDto, id = id };
            return await HandleCommand<UpdateClientTypeCommand, GetClientTypeDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ClientTypes.DeleteClientType + "/{id}")]
        public async Task<IActionResult> DeleteClientType(int id)
        {
            var command = new DeleteClientTypeCommand { Id = id };
            return await HandleCommand<DeleteClientTypeCommand, bool>(command);
        }
    }
}
