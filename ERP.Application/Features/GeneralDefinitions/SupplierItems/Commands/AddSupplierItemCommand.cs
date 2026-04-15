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
            var entity = request._addSupplierItemDTO.Adapt<Domain.Entities.GeneralDefinitions.SupplierItem>();

            var addedEntity = await _unitOfWork.SupplierItems.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetSupplierItemDto>();

                return Result<GetSupplierItemDto>.Success(dto, "SupplierItem added successfully");
            }

            return Result<GetSupplierItemDto>.Failure("Failed to add SupplierItem");
        }
    }

    public class AddSupplierItemValidator : AbstractValidator<AddSupplierItemCommand>
    {
        public AddSupplierItemValidator()
        {
            RuleFor(x => x._addSupplierItemDTO.SupplierId).GreaterThan(0).WithMessage("SupplierId is required");
            RuleFor(x => x._addSupplierItemDTO.ItemId).NotEmpty().WithMessage("Item is required");
            RuleFor(x => x._addSupplierItemDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategory is required");
        }
    }
}
