namespace ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.UpdateItemCategory
{
    public class UpdateItemCategoryCommand : IRequest<Result<GetItemCategoryDto>>
    {
        public UpdateItemCategoryDto _updateItemCategoryDTO { get; set; }
    }

    public class UpdateItemCategoryHandler : IRequestHandler<UpdateItemCategoryCommand, Result<GetItemCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemCategoryDto>> Handle(UpdateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemCategories.GetEntityByIdAsync(request._updateItemCategoryDTO.Id);
            if (entity == null)
            {
                return Result<GetItemCategoryDto>.Failure("ItemCategory not found");
            }

            entity.ItemCategoryName = request._updateItemCategoryDTO.ItemCategoryName;
            entity.AccNo = request._updateItemCategoryDTO.AccNo;
            entity.AccName = request._updateItemCategoryDTO.AccName;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.ItemCategories.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetItemCategoryDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetItemCategoryDto>.Success(dto, "ItemCategory updated successfully");
            }

            return Result<GetItemCategoryDto>.Failure("Failed to update ItemCategory");
        }
    }

    public class UpdateItemCategoryValidator : AbstractValidator<UpdateItemCategoryCommand>
    {
        public UpdateItemCategoryValidator()
        {
            RuleFor(x => x._updateItemCategoryDTO.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateItemCategoryDTO.ItemCategoryName).NotEmpty().WithMessage("ItemCategoryName is required");
            RuleFor(x => x._updateItemCategoryDTO.AccNo).NotEmpty().WithMessage("AccNo is required");
        }
    }
}
