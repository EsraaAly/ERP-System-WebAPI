namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.DeleteItemRegistry
{
    public class DeleteItemRegistryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteItemRegistryHandler : IRequestHandler<DeleteItemRegistryCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemRegistryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteItemRegistryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemRegistries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ItemRegistry not found");
            }

            var deleted = await _unitOfWork.ItemRegistries.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ItemRegistry deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ItemRegistry");
        }
    }

    public class DeleteItemRegistryValidator : AbstractValidator<DeleteItemRegistryCommand>
    {
        public DeleteItemRegistryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
