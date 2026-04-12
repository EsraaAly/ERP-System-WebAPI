namespace ERP.Application.Features.GeneralDefinitions.Stores.Queries.GetAllStores
{
    public class GetAllStoresQuery : IRequest<Result<List<GetStoreDto>>>
    {
    }

    public class GetAllStoresHandler : IRequestHandler<GetAllStoresQuery, Result<List<GetStoreDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStoresHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetStoreDto>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Stores.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetStoreDto>>();

            return Result<List<GetStoreDto>>.Success(dtos, "Stores retrieved successfully");
        }
    }
}
