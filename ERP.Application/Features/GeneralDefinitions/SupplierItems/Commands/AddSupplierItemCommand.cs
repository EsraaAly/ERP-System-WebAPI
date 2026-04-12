namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.AddSupplierItem
{
    public class AddSupplierItemCommand : IRequest<Result<GetSupplierItemDto>>
    {
        public AddSupplierItemDto _addSupplierItemDTO { get; set; }
    }

    public class AddSupplierItemHandler : IRequestHandler<AddSupplierItemCommand, Result<GetSupplierItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSupplierItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierItemDto>> Handle(AddSupplierItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.SupplierItem
            {
                SupplierID = request._addSupplierItemDTO.SupplierID,
                SupplierName = request._addSupplierItemDTO.SupplierName,
                ItemCategory = request._addSupplierItemDTO.ItemCategory,
                ItemName = request._addSupplierItemDTO.ItemName,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = null,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.SupplierItems.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetSupplierItemDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierItemDto>.Success(dto, "SupplierItem added successfully");
            }

            return Result<GetSupplierItemDto>.Failure("Failed to add SupplierItem");
        }
    }

    public class AddSupplierItemValidator : AbstractValidator<AddSupplierItemCommand>
    {
        public AddSupplierItemValidator()
        {
            RuleFor(x => x._addSupplierItemDTO.SupplierID).GreaterThan(0).WithMessage("SupplierID is required");
            RuleFor(x => x._addSupplierItemDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._addSupplierItemDTO.ItemCategory).NotEmpty().WithMessage("ItemCategory is required");
        }
    }
}
