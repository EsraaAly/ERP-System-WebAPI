namespace ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Queries.GetClientPriceListById
{
    public class GetClientPriceListByIdQuery : IRequest<Result<GetClientPriceListDto>>
    {
        public int Id { get; set; }
    }

    public class GetClientPriceListByIdHandler : IRequestHandler<GetClientPriceListByIdQuery, Result<GetClientPriceListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientPriceListByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientPriceListDto>> Handle(GetClientPriceListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientPriceLists.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetClientPriceListDto>.Failure("ClientPriceList not found");
            }

            var dto = entity.Adapt<GetClientPriceListDto>();

            return Result<GetClientPriceListDto>.Success(dto, "ClientPriceList retrieved successfully");
        }
    }

    public class GetClientPriceListByIdValidator : AbstractValidator<GetClientPriceListByIdQuery>
    {
        public GetClientPriceListByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
