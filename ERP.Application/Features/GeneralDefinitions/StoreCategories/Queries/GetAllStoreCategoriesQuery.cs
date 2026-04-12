namespace ERP.Application.Features.GeneralDefinitions.StoreCategories.Queries.GetAllStoreCategories
{
    public class GetAllStoreCategoriesQuery : IRequest<Result<List<GetStoreCategoryDto>>>
    {
    }

    public class GetAllStoreCategoriesHandler : IRequestHandler<GetAllStoreCategoriesQuery, Result<List<GetStoreCategoryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStoreCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetStoreCategoryDto>>> Handle(GetAllStoreCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.StoreCategories.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetStoreCategoryDto>>();

            return Result<List<GetStoreCategoryDto>>.Success(dtos, "StoreCategories retrieved successfully");
        }
    }
}
