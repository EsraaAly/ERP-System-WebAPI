namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.DeleteItemList
{
    public class DeleteItemListCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteItemListHandler : IRequestHandler<DeleteItemListCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteItemListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemLists.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ItemList not found");
            }

            var deleted = await _unitOfWork.ItemLists.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ItemList deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ItemList");
        }
    }

    public class DeleteItemListValidator : AbstractValidator<DeleteItemListCommand>
    {
        public DeleteItemListValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
