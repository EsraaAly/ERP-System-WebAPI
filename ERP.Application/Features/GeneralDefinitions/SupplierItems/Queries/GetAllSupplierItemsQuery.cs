namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Queries.GetAllSupplierItems
{
    public class GetAllSupplierItemsQuery : IRequest<Result<List<GetSupplierItemDto>>>
    {
    }

    public class GetAllSupplierItemsHandler : IRequestHandler<GetAllSupplierItemsQuery, Result<List<GetSupplierItemDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSupplierItemsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetSupplierItemDto>>> Handle(GetAllSupplierItemsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.SupplierItems.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetSupplierItemDto>>();

            return Result<List<GetSupplierItemDto>>.Success(dtos, "SupplierItems retrieved successfully");
        }
    }
}
