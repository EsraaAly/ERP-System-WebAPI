namespace ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.UpdateClientPriceList
{
    public class UpdateClientPriceListCommand : IRequest<Result<GetClientPriceListDto>>
    {
        public UpdateClientPriceListDto _updateClientPriceListDTO { get; set; }
    }

    public class UpdateClientPriceListHandler : IRequestHandler<UpdateClientPriceListCommand, Result<GetClientPriceListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientPriceListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientPriceListDto>> Handle(UpdateClientPriceListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientPriceLists.GetEntityByIdAsync(request._updateClientPriceListDTO.Id);
            if (entity == null)
            {
                return Result<GetClientPriceListDto>.Failure("ClientPriceList not found");
            }

            entity.ClientId = request._updateClientPriceListDTO.ClientId;
            entity.ItemId = request._updateClientPriceListDTO.ItemSNo;
            entity.ItemCategoryId = request._updateClientPriceListDTO.ItemCategoryId;
            entity.PriceWithoutVat = request._updateClientPriceListDTO.PriceWithoutVat;
            entity.Price = request._updateClientPriceListDTO.Price;
            entity.DiscountAmount = request._updateClientPriceListDTO.DiscountAmount;
            entity.PriceAfterDiscount = request._updateClientPriceListDTO.PriceAfterDiscount;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.ClientPriceLists.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                var dto = entity.Adapt<GetClientPriceListDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientPriceListDto>.Success(dto, "ClientPriceList updated successfully");
            }

            return Result<GetClientPriceListDto>.Failure("Failed to update ClientPriceList");
        }
    }

    public class UpdateClientPriceListValidator : AbstractValidator<UpdateClientPriceListCommand>
    {
        public UpdateClientPriceListValidator()
        {
            RuleFor(x => x._updateClientPriceListDTO.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientPriceListDTO.ClientId).GreaterThan(0).WithMessage("ClientId is required");
            RuleFor(x => x._updateClientPriceListDTO.ItemName).NotEmpty().WithMessage("ItemName is required");
            RuleFor(x => x._updateClientPriceListDTO.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
