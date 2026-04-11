namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Queries.GetAllItemLists
{
    public class GetAllItemListsQuery : IRequest<Result<List<GetItemListDto>>>
    {
    }

    public class GetAllItemListsHandler : IRequestHandler<GetAllItemListsQuery, Result<List<GetItemListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllItemListsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetItemListDto>>> Handle(GetAllItemListsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ItemLists.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetItemListDto>>();

            return Result<List<GetItemListDto>>.Success(dtos, "ItemLists retrieved successfully");
        }
    }
}
