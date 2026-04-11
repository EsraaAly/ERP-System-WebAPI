namespace ERP.Application.Features.GeneralDefinitions.SupplierContacts.Queries.GetAllSupplierContacts
{
    public class GetAllSupplierContactsQuery : IRequest<Result<List<GetSupplierContactDto>>>
    {
    }

    public class GetAllSupplierContactsHandler : IRequestHandler<GetAllSupplierContactsQuery, Result<List<GetSupplierContactDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSupplierContactsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetSupplierContactDto>>> Handle(GetAllSupplierContactsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.SupplierContacts.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetSupplierContactDto>>();

            return Result<List<GetSupplierContactDto>>.Success(dtos, "SupplierContacts retrieved successfully");
        }
    }
}
