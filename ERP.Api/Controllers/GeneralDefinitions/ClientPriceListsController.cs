namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class ClientPriceListsController : BaseController
    {
        public ClientPriceListsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.ClientPriceLists.AddClientPriceList)]
        public async Task<IActionResult> CreateClientPriceList([FromBody] AddClientPriceListDto clientPriceListDto)
        {
            var command = new AddClientPriceListCommand { _addClientPriceListDTO = clientPriceListDto };
            return await HandleCommand<AddClientPriceListCommand, GetClientPriceListDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientPriceLists.GetClientPriceListById)]
        public async Task<IActionResult> GetClientPriceListById(int id)
        {
            var query = new GetClientPriceListByIdQuery { Id = id };
            return await HandleQueryWithData<GetClientPriceListByIdQuery, GetClientPriceListDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.ClientPriceLists.GetAllClientPriceLists)]
        public async Task<IActionResult> GetAllClientPriceLists()
        {
            var query = new GetAllClientPriceListsQuery();
            return await HandleQueryWithData<GetAllClientPriceListsQuery, List<GetClientPriceListDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.ClientPriceLists.UpdateClientPriceList)]
        public async Task<IActionResult> UpdateClientPriceList(int id, [FromBody] UpdateClientPriceListDto clientPriceListDto)
        {
            if (id != clientPriceListDto.Id)
            {
                return BadRequest("ID mismatch between route parameter and request body");
            }

            var command = new UpdateClientPriceListCommand { _updateClientPriceListDTO = clientPriceListDto };
            return await HandleCommand<UpdateClientPriceListCommand, GetClientPriceListDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.ClientPriceLists.DeleteClientPriceList)]
        public async Task<IActionResult> DeleteClientPriceList(int id)
        {
            var command = new DeleteClientPriceListCommand { Id = id };
            return await HandleCommand<DeleteClientPriceListCommand, bool>(command);
        }
    }
}
