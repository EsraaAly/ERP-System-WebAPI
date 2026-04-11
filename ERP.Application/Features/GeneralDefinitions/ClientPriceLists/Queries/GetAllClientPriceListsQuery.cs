namespace ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Queries.GetAllClientPriceLists
{
    public class GetAllClientPriceListsQuery : IRequest<Result<List<GetClientPriceListDto>>>
    {
    }

    public class GetAllClientPriceListsHandler : IRequestHandler<GetAllClientPriceListsQuery, Result<List<GetClientPriceListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientPriceListsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetClientPriceListDto>>> Handle(GetAllClientPriceListsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ClientPriceLists.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetClientPriceListDto>>();

            return Result<List<GetClientPriceListDto>>.Success(dtos, "ClientPriceLists retrieved successfully");
        }
    }
}
