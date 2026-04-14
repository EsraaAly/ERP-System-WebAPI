namespace ERP.Application.Features.GeneralDefinitions.Stores.Commands.AddStore
{
    public class AddStoreCommand : IRequest<Result<GetStoreDto>>
    {
        public AddStoreDto _addStoreDTO { get; set; }
    }

    public class AddStoreHandler : IRequestHandler<AddStoreCommand, Result<GetStoreDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddStoreHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetStoreDto>> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addStoreDTO.Adapt<Domain.Entities.GeneralDefinitions.Store>();

            var addedEntity = await _unitOfWork.Stores.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetStoreDto>();
                return Result<GetStoreDto>.Success(dto, "Store added successfully");
            }

            return Result<GetStoreDto>.Failure("Failed to add Store");
        }
    }

    public class AddStoreValidator : AbstractValidator<AddStoreCommand>
    {
        public AddStoreValidator()
        {
            RuleFor(x => x._addStoreDTO.StoreName).NotEmpty().WithMessage("StoreName is required");
            RuleFor(x => x._addStoreDTO.StoreId).GreaterThan(0).WithMessage("StoreId is required");
            RuleFor(x => x._addStoreDTO.StoreCategoryId).GreaterThan(0).WithMessage("StoreCategory is required");
        }
    }
}
