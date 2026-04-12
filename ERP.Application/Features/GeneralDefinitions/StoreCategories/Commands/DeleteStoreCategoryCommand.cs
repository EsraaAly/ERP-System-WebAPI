namespace ERP.Application.Features.GeneralDefinitions.StoreCategories.Commands.DeleteStoreCategory
{
    public class DeleteStoreCategoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteStoreCategoryHandler : IRequestHandler<DeleteStoreCategoryCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteStoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.StoreCategories.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("StoreCategory not found");
            }

            var deletedEntity = await _unitOfWork.StoreCategories.DeleteEntityAsync(entity.Id);
            if (deletedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "StoreCategory deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete StoreCategory");
        }
    }

    public class DeleteStoreCategoryValidator : AbstractValidator<DeleteStoreCategoryCommand>
    {
        public DeleteStoreCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
