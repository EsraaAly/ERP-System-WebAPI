namespace ERP.Application.Features.GeneralDefinitions.StoreCategories.Commands.UpdateStoreCategory
{
    public class UpdateStoreCategoryCommand : IRequest<Result<GetStoreCategoryDto>>
    {
        public int Id { get; set; }
        public UpdateStoreCategoryDto _updateStoreCategoryDTO { get; set; }
    }

    public class UpdateStoreCategoryHandler : IRequestHandler<UpdateStoreCategoryCommand, Result<GetStoreCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreCategoryDto>> Handle(UpdateStoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.StoreCategories.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetStoreCategoryDto>.Failure("StoreCategory not found");
            }

            entity.CategoryName = request._updateStoreCategoryDTO.CategoryName;
            entity.CategoryNameAr = request._updateStoreCategoryDTO.CategoryNameAr;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.StoreCategories.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetStoreCategoryDto>();
                return Result<GetStoreCategoryDto>.Success(dto, "StoreCategory updated successfully");
            }

            return Result<GetStoreCategoryDto>.Failure("Failed to update StoreCategory");
        }
    }

    public class UpdateStoreCategoryValidator : AbstractValidator<UpdateStoreCategoryCommand>
    {
        public UpdateStoreCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateStoreCategoryDTO.CategoryName).NotEmpty().WithMessage("CategoryName is required");
            RuleFor(x => x._updateStoreCategoryDTO.CategoryNameAr).NotEmpty().WithMessage("CategoryNameAr is required");
        }
    }
}
