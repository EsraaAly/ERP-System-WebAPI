namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.UpdateItemList
{
    public class UpdateItemListCommand : IRequest<Result<GetItemListDto>>
    {
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
            var entity = await _unitOfWork.ItemLists.GetEntityByIdAsync(request._updateItemListDTO.Id);
            if (entity == null)
            {
                return Result<GetItemListDto>.Failure("ItemList not found");
            }

            entity.Category = request._updateItemListDTO.Category;
            entity.ItemName = request._updateItemListDTO.ItemName;
            entity.Unit = request._updateItemListDTO.Unit;
            entity.Sales = request._updateItemListDTO.Sales;
            entity.MinimumLevel = request._updateItemListDTO.MinimumLevel;
            entity.ItemOrder = request._updateItemListDTO.ItemOrder;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.ItemLists.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetItemListDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetItemListDto>.Success(dto, "ItemList updated successfully");
            }

            return Result<GetItemListDto>.Failure("Failed to update ItemList");
        }
    }

    public class UpdateItemListValidator : AbstractValidator<UpdateItemListCommand>
    {
        public UpdateItemListValidator()
        {
            RuleFor(x => x._updateItemListDTO.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateItemListDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._updateItemListDTO.Category).NotEmpty().WithMessage("Category is required");
        }
    }
}
