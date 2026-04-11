namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.UpdateItemRegistry
{
    public class UpdateItemRegistryCommand : IRequest<Result<GetItemRegistryDto>>
    {
        public UpdateItemRegistryDto _updateItemRegistryDTO { get; set; }
    }

    public class UpdateItemRegistryHandler : IRequestHandler<UpdateItemRegistryCommand, Result<GetItemRegistryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemRegistryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemRegistryDto>> Handle(UpdateItemRegistryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemRegistries.GetEntityByIdAsync(request._updateItemRegistryDTO.Id);
            if (entity == null)
            {
                return Result<GetItemRegistryDto>.Failure("ItemRegistry not found");
            }

            entity.ItemCategory = request._updateItemRegistryDTO.ItemCategory;
            entity.ItemName = request._updateItemRegistryDTO.ItemName;
            entity.ClientType = request._updateItemRegistryDTO.ClientType;
            entity.Region = request._updateItemRegistryDTO.Region;
            entity.PriceWithoutVat = request._updateItemRegistryDTO.PriceWithoutVat;
            entity.Price = request._updateItemRegistryDTO.Price;
            entity.DiscountAmount = request._updateItemRegistryDTO.DiscountAmount;
            entity.PriceAfterDiscount = request._updateItemRegistryDTO.PriceAfterDiscount;
            entity.Details = request._updateItemRegistryDTO.Details;
            entity.ItemOrder = request._updateItemRegistryDTO.ItemOrder;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.ItemRegistries.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetItemRegistryDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetItemRegistryDto>.Success(dto, "ItemRegistry updated successfully");
            }

            return Result<GetItemRegistryDto>.Failure("Failed to update ItemRegistry");
        }
    }

    public class UpdateItemRegistryValidator : AbstractValidator<UpdateItemRegistryCommand>
    {
        public UpdateItemRegistryValidator()
        {
            RuleFor(x => x._updateItemRegistryDTO.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateItemRegistryDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._updateItemRegistryDTO.ItemCategory).NotEmpty().WithMessage("ItemCategory is required");
            RuleFor(x => x._updateItemRegistryDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
