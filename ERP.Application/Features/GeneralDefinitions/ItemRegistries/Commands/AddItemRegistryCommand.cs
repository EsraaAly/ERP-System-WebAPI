namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.AddItemRegistry
{
    public class AddItemRegistryCommand : IRequest<Result<GetItemRegistryDto>>
    {
        public AddItemRegistryDto _addItemRegistryDTO { get; set; }
    }

    public class AddItemRegistryHandler : IRequestHandler<AddItemRegistryCommand, Result<GetItemRegistryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddItemRegistryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemRegistryDto>> Handle(AddItemRegistryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.ItemRegistry
            {
                ItemCategoryId = request._addItemRegistryDTO.ItemCategoryId,
                ItemName = request._addItemRegistryDTO.ItemName,
                ClientTypeId = request._addItemRegistryDTO.ClientTypeId,
                RegionId = request._addItemRegistryDTO.RegionId,
                StoreId = request._addItemRegistryDTO.StoreId,
                PriceWithoutVat = request._addItemRegistryDTO.PriceWithoutVat,
                Price = request._addItemRegistryDTO.Price,
                DiscountAmount = request._addItemRegistryDTO.DiscountAmount,
                PriceAfterDiscount = request._addItemRegistryDTO.PriceAfterDiscount,
                Details = request._addItemRegistryDTO.Details,
                ItemOrder = request._addItemRegistryDTO.ItemOrder,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.ItemRegistries.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetItemRegistryDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetItemRegistryDto>.Success(dto, "ItemRegistry added successfully");
            }

            return Result<GetItemRegistryDto>.Failure("Failed to add ItemRegistry");
        }
    }

    public class AddItemRegistryValidator : AbstractValidator<AddItemRegistryCommand>
    {
        public AddItemRegistryValidator()
        {
            RuleFor(x => x._addItemRegistryDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._addItemRegistryDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategoryId is required");
            RuleFor(x => x._addItemRegistryDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
