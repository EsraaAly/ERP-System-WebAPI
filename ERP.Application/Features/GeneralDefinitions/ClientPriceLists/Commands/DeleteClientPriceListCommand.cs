namespace ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.DeleteClientPriceList
{
    public class DeleteClientPriceListCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientPriceListHandler : IRequestHandler<DeleteClientPriceListCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientPriceListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteClientPriceListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientPriceLists.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ClientPriceList not found");
            }

            var deleted = await _unitOfWork.ClientPriceLists.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ClientPriceList deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ClientPriceList");
        }
    }

    public class DeleteClientPriceListValidator : AbstractValidator<DeleteClientPriceListCommand>
    {
        public DeleteClientPriceListValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
