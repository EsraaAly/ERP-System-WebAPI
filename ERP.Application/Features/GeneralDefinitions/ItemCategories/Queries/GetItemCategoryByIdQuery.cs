namespace ERP.Application.Features.GeneralDefinitions.ItemCategories.Queries.GetItemCategoryById
{
    public class GetItemCategoryByIdQuery : IRequest<Result<GetItemCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetItemCategoryByIdHandler : IRequestHandler<GetItemCategoryByIdQuery, Result<GetItemCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetItemCategoryByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemCategoryDto>> Handle(GetItemCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemCategories.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetItemCategoryDto>.Failure("ItemCategory not found");
            }

            var dto = entity.Adapt<GetItemCategoryDto>();

            return Result<GetItemCategoryDto>.Success(dto, "ItemCategory retrieved successfully");
        }
    }

    public class GetItemCategoryByIdValidator : AbstractValidator<GetItemCategoryByIdQuery>
    {
        public GetItemCategoryByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
