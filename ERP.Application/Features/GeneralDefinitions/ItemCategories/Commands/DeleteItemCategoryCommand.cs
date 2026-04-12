namespace ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.DeleteItemCategory
{
    public class DeleteItemCategoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteItemCategoryHandler : IRequestHandler<DeleteItemCategoryCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemCategories.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ItemCategory not found");
            }

            var deleted = await _unitOfWork.ItemCategories.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ItemCategory deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ItemCategory");
        }
    }

    public class DeleteItemCategoryValidator : AbstractValidator<DeleteItemCategoryCommand>
    {
        public DeleteItemCategoryValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
