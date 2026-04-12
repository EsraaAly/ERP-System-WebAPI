namespace ERP.Application.Features.GeneralDefinitions.StoreCategories.Queries.GetStoreCategoryById
{
    public class GetStoreCategoryByIdQuery : IRequest<Result<GetStoreCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetStoreCategoryByIdHandler : IRequestHandler<GetStoreCategoryByIdQuery, Result<GetStoreCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStoreCategoryByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreCategoryDto>> Handle(GetStoreCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.StoreCategories.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetStoreCategoryDto>.Failure("StoreCategory not found");
            }

            var dto = entity.Adapt<GetStoreCategoryDto>();
            return Result<GetStoreCategoryDto>.Success(dto, "StoreCategory retrieved successfully");
        }
    }
}
