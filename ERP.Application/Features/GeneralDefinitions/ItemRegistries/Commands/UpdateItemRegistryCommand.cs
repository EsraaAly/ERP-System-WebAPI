namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.UpdateItemRegistry
{
    public class UpdateItemRegistryCommand : IRequest<Result<GetItemRegistryDto>>
    {
        public int Id { get; set; }
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
            var entity = await _unitOfWork.ItemRegistries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetItemRegistryDto>.Failure("ItemRegistry not found");
            }

            entity.ItemId = request._updateItemRegistryDTO.ItemId;
            entity.ClientTypeId = request._updateItemRegistryDTO.ClientTypeId;
            entity.RegionId = request._updateItemRegistryDTO.RegionId;
            entity.StoreId = request._updateItemRegistryDTO.StoreId;
            entity.PriceWithoutVat = request._updateItemRegistryDTO.PriceWithoutVat;
            entity.Price = request._updateItemRegistryDTO.Price;
            entity.DiscountAmount = request._updateItemRegistryDTO.DiscountAmount;
            entity.PriceAfterDiscount = request._updateItemRegistryDTO.PriceAfterDiscount;
            entity.Details = request._updateItemRegistryDTO.Details;
            entity.ItemOrder = request._updateItemRegistryDTO.ItemOrder;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.ItemRegistries.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetItemRegistryDto>();
                return Result<GetItemRegistryDto>.Success(dto, "ItemRegistry updated successfully");
            }

            return Result<GetItemRegistryDto>.Failure("Failed to update ItemRegistry");
        }
    }

    public class UpdateItemRegistryValidator : AbstractValidator<UpdateItemRegistryCommand>
    {
        public UpdateItemRegistryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateItemRegistryDTO.ItemId).GreaterThan(0).WithMessage("ItemId is required");
            RuleFor(x => x._updateItemRegistryDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
