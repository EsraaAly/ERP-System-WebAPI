namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<Result<List<GetSupplierDto>>>
    {
        public string? Name { get; set; }
        public int? SupplierTypeId { get; set; }
        public int? CountryId { get; set; }
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
            var entities = await _unitOfWork.Suppliers.GetListByExpressionAsync(
                x => (string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name)) &&
                     (!request.SupplierTypeId.HasValue || x.SupplierTypeId == request.SupplierTypeId) &&
                     (!request.CountryId.HasValue || x.CountryId == request.CountryId),
                x => x.SupplierType,
                x => x.country
            );

            var dtos = entities.Adapt<List<GetSupplierDto>>();

            return Result<List<GetSupplierDto>>.Success(dtos, "Suppliers retrieved successfully");
        }
    }
}
