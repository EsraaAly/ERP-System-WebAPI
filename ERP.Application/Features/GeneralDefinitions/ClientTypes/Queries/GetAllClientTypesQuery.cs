namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Queries.GetAllClientTypes
{
    public class GetAllClientTypesQuery : IRequest<Result<List<GetClientTypeDto>>>
    {
    }

    public class GetAllClientTypesHandler : IRequestHandler<GetAllClientTypesQuery, Result<List<GetClientTypeDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientTypesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetClientTypeDto>>> Handle(GetAllClientTypesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ClientTypes.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetClientTypeDto>>();

            return Result<List<GetClientTypeDto>>.Success(dtos, "ClientTypes retrieved successfully");
        }
    }
}
