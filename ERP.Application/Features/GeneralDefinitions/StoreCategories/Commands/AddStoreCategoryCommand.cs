namespace ERP.Application.Features.GeneralDefinitions.StoreCategories.Commands.AddStoreCategory
{
    public class AddStoreCategoryCommand : IRequest<Result<GetStoreCategoryDto>>
    {
        public AddStoreCategoryDto _addStoreCategoryDTO { get; set; }
    }

    public class AddStoreCategoryHandler : IRequestHandler<AddStoreCategoryCommand, Result<GetStoreCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddStoreCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreCategoryDto>> Handle(AddStoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.StoreCategory
            {
                CategoryName = request._addStoreCategoryDTO.CategoryName,
                CategoryNameAr = request._addStoreCategoryDTO.CategoryNameAr,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.StoreCategories.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetStoreCategoryDto>();
                return Result<GetStoreCategoryDto>.Success(dto, "StoreCategory added successfully");
            }

            return Result<GetStoreCategoryDto>.Failure("Failed to add StoreCategory");
        }
    }

    public class AddStoreCategoryValidator : AbstractValidator<AddStoreCategoryCommand>
    {
        public AddStoreCategoryValidator()
        {
            RuleFor(x => x._addStoreCategoryDTO.CategoryName).NotEmpty().WithMessage("CategoryName is required");
            RuleFor(x => x._addStoreCategoryDTO.CategoryNameAr).NotEmpty().WithMessage("CategoryNameAr is required");
        }
    }
}
