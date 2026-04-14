namespace ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.AddItemCategory
{
    public class AddItemCategoryCommand : IRequest<Result<GetItemCategoryDto>>
    {
        public AddItemCategoryDto _addItemCategoryDTO { get; set; }
    }

    public class AddItemCategoryHandler : IRequestHandler<AddItemCategoryCommand, Result<GetItemCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddItemCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemCategoryDto>> Handle(AddItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.ItemCategory
            {
                ItemCategoryName = request._addItemCategoryDTO.ItemCategoryName,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.ItemCategories.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetItemCategoryDto>();
                return Result<GetItemCategoryDto>.Success(dto, "ItemCategory added successfully");
            }

            return Result<GetItemCategoryDto>.Failure("Failed to add ItemCategory");
        }
    }

    public class AddItemCategoryValidator : AbstractValidator<AddItemCategoryCommand>
    {
        public AddItemCategoryValidator()
        {
            RuleFor(x => x._addItemCategoryDTO.ItemCategoryName).NotEmpty().WithMessage("ItemCategoryName is required");
            RuleFor(x => x._addItemCategoryDTO.AccNo).NotEmpty().WithMessage("AccNo is required");
        }
    }
}
