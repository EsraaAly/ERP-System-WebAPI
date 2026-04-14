namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.UpdateSupplierItem
{
    public class UpdateSupplierItemCommand : IRequest<Result<GetSupplierItemDto>>
    {
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
            var entity = await _unitOfWork.SupplierItems.GetEntityByIdAsync(request._updateSupplierItemDTO.Id);
            if (entity == null)
            {
                return Result<GetSupplierItemDto>.Failure("SupplierItem not found");
            }

            entity.SupplierID = request._updateSupplierItemDTO.SupplierID;
            entity.SupplierName = request._updateSupplierItemDTO.SupplierName;
            entity.ItemCategoryId = request._updateSupplierItemDTO.ItemCategoryId;
            entity.ItemName = request._updateSupplierItemDTO.ItemName;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.SupplierItems.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetSupplierItemDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierItemDto>.Success(dto, "SupplierItem updated successfully");
            }

            return Result<GetSupplierItemDto>.Failure("Failed to update SupplierItem");
        }
    }

    public class UpdateSupplierItemValidator : AbstractValidator<UpdateSupplierItemCommand>
    {
        public UpdateSupplierItemValidator()
        {
            RuleFor(x => x._updateSupplierItemDTO.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierItemDTO.SupplierID).GreaterThan(0).WithMessage("SupplierID is required");
            RuleFor(x => x._updateSupplierItemDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._updateSupplierItemDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategoryId is required");
        }
    }
}
