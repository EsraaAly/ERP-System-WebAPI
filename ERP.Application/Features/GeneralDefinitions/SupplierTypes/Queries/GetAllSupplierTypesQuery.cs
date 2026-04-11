namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Queries.GetAllSupplierTypes
{
    public class GetAllSupplierTypesQuery : IRequest<Result<List<GetSupplierTypeDto>>>
    {
    }

    public class GetAllSupplierTypesHandler : IRequestHandler<GetAllSupplierTypesQuery, Result<List<GetSupplierTypeDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSupplierTypesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetSupplierTypeDto>>> Handle(GetAllSupplierTypesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.SupplierTypes.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetSupplierTypeDto>>();

            return Result<List<GetSupplierTypeDto>>.Success(dtos, "SupplierTypes retrieved successfully");
        }
    }
}
