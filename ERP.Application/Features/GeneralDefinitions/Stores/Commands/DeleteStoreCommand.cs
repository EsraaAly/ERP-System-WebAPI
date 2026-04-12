namespace ERP.Application.Features.GeneralDefinitions.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Stores.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Store not found");
            }

            var deletedEntity = await _unitOfWork.Stores.DeleteEntityAsync(entity.Id);
            if (deletedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Store deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Store");
        }
    }

    public class DeleteStoreValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
