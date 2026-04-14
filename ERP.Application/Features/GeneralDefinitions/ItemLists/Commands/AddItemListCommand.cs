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
            var entity = request._addItemListDTO.Adapt<Domain.Entities.GeneralDefinitions.ItemList>();

            var addedEntity = await _unitOfWork.ItemLists.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetItemListDto>();
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
            RuleFor(x => x._addItemListDTO.ItemCategoryId).GreaterThan(0).WithMessage("ItemCategoryId is required");
            RuleFor(x => x._addItemListDTO.Sales).IsInEnum();
        }
    }
}
