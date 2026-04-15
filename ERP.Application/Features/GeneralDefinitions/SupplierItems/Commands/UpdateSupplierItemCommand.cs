namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.UpdateSupplierItem
{
    public class UpdateSupplierItemCommand : IRequest<Result<GetSupplierItemDto>>
    {
        public int Id { get; set; }
        public UpdateSupplierItemDto _updateSupplierItemDTO { get; set; }
    }

    public class UpdateSupplierItemHandler : IRequestHandler<UpdateSupplierItemCommand, Result<GetSupplierItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierItemDto>> Handle(UpdateSupplierItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierItems.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierItemDto>.Failure("SupplierItem not found");
            }

            entity.SupplierId = request._updateSupplierItemDTO.SupplierId;
            entity.ItemCategoryId = request._updateSupplierItemDTO.ItemCategoryId;
            entity.ItemId = request._updateSupplierItemDTO.ItemId;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.SupplierItems.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetSupplierItemDto>();
                return Result<GetSupplierItemDto>.Success(dto, "SupplierItem updated successfully");
            }

            return Result<GetSupplierItemDto>.Failure("Failed to update SupplierItem");
        }
    }

    public class UpdateSupplierItemValidator : AbstractValidator<UpdateSupplierItemCommand>
    {
        public UpdateSupplierItemValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierItemDTO.SupplierId).GreaterThan(0).WithMessage("SupplierId is required");
            RuleFor(x => x._updateSupplierItemDTO.ItemId).NotEmpty().WithMessage("Item is required");
            RuleFor(x => x._updateSupplierItemDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategory is required");
        }
    }
}
