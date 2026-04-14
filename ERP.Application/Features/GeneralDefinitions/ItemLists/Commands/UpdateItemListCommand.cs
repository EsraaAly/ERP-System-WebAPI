namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.UpdateItemList
{
    public class UpdateItemListCommand : IRequest<Result<GetItemListDto>>
    {
        public int Id { get; set; }
        public UpdateItemListDto _updateItemListDTO { get; set; }
    }

    public class UpdateItemListHandler : IRequestHandler<UpdateItemListCommand, Result<GetItemListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemListDto>> Handle(UpdateItemListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemLists.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetItemListDto>.Failure("ItemList not found");
            }

            entity.ItemCategoryId = request._updateItemListDTO.ItemCategoryId;
            entity.ItemName = request._updateItemListDTO.ItemName;
            entity.UnitId = request._updateItemListDTO.UnitId;
            entity.Sales = request._updateItemListDTO.Sales;
            entity.MinimumLevel = request._updateItemListDTO.MinimumLevel;
            entity.ItemOrder = request._updateItemListDTO.ItemOrder;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.ItemLists.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity .Adapt<GetItemListDto>();

                return Result<GetItemListDto>.Success(dto, "ItemList updated successfully");
            }

            return Result<GetItemListDto>.Failure("Failed to update ItemList");
        }
    }

    public class UpdateItemListValidator : AbstractValidator<UpdateItemListCommand>
    {
        public UpdateItemListValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateItemListDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._updateItemListDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategoryId is required");
        }
    }
}
