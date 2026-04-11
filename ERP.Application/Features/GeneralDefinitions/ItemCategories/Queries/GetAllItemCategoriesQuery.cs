namespace ERP.Application.Features.GeneralDefinitions.ItemCategories.Queries.GetAllItemCategories
{
    public class GetAllItemCategoriesQuery : IRequest<Result<List<GetItemCategoryDto>>>
    {
    }

    public class GetAllItemCategoriesHandler : IRequestHandler<GetAllItemCategoriesQuery, Result<List<GetItemCategoryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllItemCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetItemCategoryDto>>> Handle(GetAllItemCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ItemCategories.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetItemCategoryDto>>();

            return Result<List<GetItemCategoryDto>>.Success(dtos, "ItemCategories retrieved successfully");
        }
    }
}
