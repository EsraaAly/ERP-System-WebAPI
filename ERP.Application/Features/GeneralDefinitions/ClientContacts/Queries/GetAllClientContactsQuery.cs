namespace ERP.Application.Features.GeneralDefinitions.ClientContacts.Queries.GetAllClientContacts
{
    public class GetAllClientContactsQuery : IRequest<Result<List<GetClientContactDto>>>
    {
    }

    public class GetAllClientContactsHandler : IRequestHandler<GetAllClientContactsQuery, Result<List<GetClientContactDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientContactsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetClientContactDto>>> Handle(GetAllClientContactsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ClientContacts.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetClientContactDto>>();

            return Result<List<GetClientContactDto>>.Success(dtos, "ClientContacts retrieved successfully");
        }
    }
}
