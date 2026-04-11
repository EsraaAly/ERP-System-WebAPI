namespace ERP.Application.Features.GeneralDefinitions.ItemLists.Queries.GetItemListById
{
    public class GetItemListByIdQuery : IRequest<Result<GetItemListDto>>
    {
        public int Id { get; set; }
    }

    public class GetItemListByIdHandler : IRequestHandler<GetItemListByIdQuery, Result<GetItemListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetItemListByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemListDto>> Handle(GetItemListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemLists.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetItemListDto>.Failure("ItemList not found");
            }

            var dto = entity.Adapt<GetItemListDto>();

            return Result<GetItemListDto>.Success(dto, "ItemList retrieved successfully");
        }
    }

    public class GetItemListByIdValidator : AbstractValidator<GetItemListByIdQuery>
    {
        public GetItemListByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
