using ERP.Domain.Enums;

namespace ERP.Application.Features.GeneralDefinitions.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<Result<List<GetClientDto>>>
    {
        public string? Name { get; set; }
        public int? RegionId { get; set; }
        public int? ClientTypeId { get; set; }
        public string? Supervisor { get; set; }
        public List<ClientStatus>? Statuses { get; set; }
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
            var entities = await _unitOfWork.Clients.GetListByExpressionAsync(
                        x => (string.IsNullOrEmpty(request.Name) || x.FullName.Contains(request.Name)) &&
                             (!request.RegionId.HasValue || x.RegionId == request.RegionId) &&
                             (!request.ClientTypeId.HasValue || x.ClientTypeId == request.ClientTypeId) &&
                             (string.IsNullOrEmpty(request.Supervisor) || x.Supervisor.Contains(request.Supervisor)) &&
                             (request.Statuses == null || !request.Statuses.Any() || request.Statuses.Contains(x.Status)));

            var dtos = entities.Adapt<List<GetClientDto>>();

            return Result<List<GetClientDto>>.Success(dtos, "Clients retrieved successfully");
        }
    }
}
