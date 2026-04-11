namespace ERP.Application.Features.GeneralDefinitions.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<Result<List<GetClientDto>>>
    {
    }

    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, Result<List<GetClientDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Clients.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetClientDto>>();

            return Result<List<GetClientDto>>.Success(dtos, "Clients retrieved successfully");
        }
    }
}
