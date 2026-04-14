namespace ERP.Application.Features.GeneralDefinitions.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest<Result<GetStoreDto>>
    {
        public int Id { get; set; }
        public UpdateStoreDto _updateStoreDTO { get; set; }
    }

    public class UpdateStoreHandler : IRequestHandler<UpdateStoreCommand, Result<GetStoreDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreDto>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Stores.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetStoreDto>.Failure("Store not found");
            }

            entity.StoreName = request._updateStoreDTO.StoreName;
            entity.StoreId = request._updateStoreDTO.StoreId;
            entity.StoreCategoryId = request._updateStoreDTO.StoreCategoryId;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.Stores.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetStoreDto>();
                return Result<GetStoreDto>.Success(dto, "Store updated successfully");
            }

            return Result<GetStoreDto>.Failure("Failed to update Store");
        }
    }

    public class UpdateStoreValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateStoreDTO.StoreName).NotEmpty().WithMessage("StoreName is required");
            RuleFor(x => x._updateStoreDTO.StoreId).GreaterThan(0).WithMessage("StoreId is required");
            RuleFor(x => x._updateStoreDTO.StoreCategoryId).GreaterThan(0).WithMessage("StoreCategory is required");
        }
    }
}
