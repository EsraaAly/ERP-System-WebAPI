namespace ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.AddClientPriceList
{
    public class AddClientPriceListCommand : IRequest<Result<GetClientPriceListDto>>
    {
        public AddClientPriceListDto _addClientPriceListDTO { get; set; }
    }

    public class AddClientPriceListHandler : IRequestHandler<AddClientPriceListCommand, Result<GetClientPriceListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClientPriceListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientPriceListDto>> Handle(AddClientPriceListCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addClientPriceListDTO.Adapt<Domain.Entities.GeneralDefinitions.ClientPriceList>();

            var addedEntity = await _unitOfWork.ClientPriceLists.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetClientPriceListDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientPriceListDto>.Success(dto, "ClientPriceList added successfully");
            }

            return Result<GetClientPriceListDto>.Failure("Failed to add ClientPriceList");
        }
    }

    public class AddClientPriceListValidator : AbstractValidator<AddClientPriceListCommand>
    {
        public AddClientPriceListValidator()
        {
            RuleFor(x => x._addClientPriceListDTO.ClientID).GreaterThan(0).WithMessage("ClientID is required");
            RuleFor(x => x._addClientPriceListDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._addClientPriceListDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
