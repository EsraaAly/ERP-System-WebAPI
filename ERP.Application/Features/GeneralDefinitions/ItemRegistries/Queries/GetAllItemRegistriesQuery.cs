namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Queries.GetAllItemRegistries
{
    public class GetAllItemRegistriesQuery : IRequest<Result<List<GetItemRegistryDto>>>
    {
    }

    public class GetAllItemRegistriesHandler : IRequestHandler<GetAllItemRegistriesQuery, Result<List<GetItemRegistryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllItemRegistriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetItemRegistryDto>>> Handle(GetAllItemRegistriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ItemRegistries.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetItemRegistryDto>>();

            return Result<List<GetItemRegistryDto>>.Success(dtos, "ItemRegistries retrieved successfully");
        }
    }
}
