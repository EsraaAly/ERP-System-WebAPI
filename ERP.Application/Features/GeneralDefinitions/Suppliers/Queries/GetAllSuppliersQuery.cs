namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<Result<List<GetSupplierDto>>>
    {
    }

    public class GetAllSuppliersHandler : IRequestHandler<GetAllSuppliersQuery, Result<List<GetSupplierDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSuppliersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetSupplierDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Suppliers.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetSupplierDto>>();

            return Result<List<GetSupplierDto>>.Success(dtos, "Suppliers retrieved successfully");
        }
    }
}
