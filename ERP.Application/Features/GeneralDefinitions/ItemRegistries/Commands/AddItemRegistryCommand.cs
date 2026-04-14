namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.AddItemRegistry
{
    public class AddItemRegistryCommand : IRequest<Result<GetItemRegistryDto>>
    {
        public AddItemRegistryDto _addItemRegistryDTO { get; set; }
    }

    public class AddItemRegistryHandler : IRequestHandler<AddItemRegistryCommand, Result<GetItemRegistryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddItemRegistryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemRegistryDto>> Handle(AddItemRegistryCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addItemRegistryDTO.Adapt<Domain.Entities.GeneralDefinitions.ItemRegistry>();

            var addedEntity = await _unitOfWork.ItemRegistries.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetItemRegistryDto>();
                return Result<GetItemRegistryDto>.Success(dto, "ItemRegistry added successfully");
            }

            return Result<GetItemRegistryDto>.Failure("Failed to add ItemRegistry");
        }
    }

    public class AddItemRegistryValidator : AbstractValidator<AddItemRegistryCommand>
    {
        public AddItemRegistryValidator()
        {
            RuleFor(x => x._addItemRegistryDTO.ItemId).GreaterThan(0).WithMessage("ItemId is required");
            RuleFor(x => x._addItemRegistryDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
