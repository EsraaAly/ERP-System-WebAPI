namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.AddItemList
{
    public class AddItemListCommand : IRequest<Result<GetItemListDto>>
    {
        public AddItemListDto _addItemListDTO { get; set; }
    }

    public class AddItemListHandler : IRequestHandler<AddItemListCommand, Result<GetItemListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddItemListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemListDto>> Handle(AddItemListCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.ItemList
            {
                Category = request._addItemListDTO.Category,
                ItemName = request._addItemListDTO.ItemName,
                Unit = request._addItemListDTO.Unit,
                Sales = request._addItemListDTO.Sales,
                MinimumLevel = request._addItemListDTO.MinimumLevel,
                ItemOrder = request._addItemListDTO.ItemOrder,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.ItemLists.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetItemListDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetItemListDto>.Success(dto, "ItemList added successfully");
            }

            return Result<GetItemListDto>.Failure("Failed to add ItemList");
        }
    }

    public class AddItemListValidator : AbstractValidator<AddItemListCommand>
    {
        public AddItemListValidator()
        {
            RuleFor(x => x._addItemListDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._addItemListDTO.Category).NotEmpty().WithMessage("Category is required");
        }
    }
}
