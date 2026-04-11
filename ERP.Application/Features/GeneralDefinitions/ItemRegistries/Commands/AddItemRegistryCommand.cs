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
                ItemCategory = request._addItemRegistryDTO.ItemCategory,
                ItemName = request._addItemRegistryDTO.ItemName,
                ClientType = request._addItemRegistryDTO.ClientType,
                Region = request._addItemRegistryDTO.Region,
                PriceWithoutVat = request._addItemRegistryDTO.PriceWithoutVat,
                Price = request._addItemRegistryDTO.Price,
                DiscountAmount = request._addItemRegistryDTO.DiscountAmount,
                PriceAfterDiscount = request._addItemRegistryDTO.PriceAfterDiscount,
                Details = request._addItemRegistryDTO.Details,
                ItemOrder = request._addItemRegistryDTO.ItemOrder,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
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
            RuleFor(x => x._addItemRegistryDTO.ItemCategory).NotEmpty().WithMessage("ItemCategory is required");
            RuleFor(x => x._addItemRegistryDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
