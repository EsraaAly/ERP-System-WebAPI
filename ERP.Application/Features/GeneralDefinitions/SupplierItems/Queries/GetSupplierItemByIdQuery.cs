namespace ERP.Application.Features.GeneralDefinitions.SupplierItems.Queries.GetSupplierItemById
{
    public class GetSupplierItemByIdQuery : IRequest<Result<GetSupplierItemDto>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierItemByIdHandler : IRequestHandler<GetSupplierItemByIdQuery, Result<GetSupplierItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupplierItemByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierItemDto>> Handle(GetSupplierItemByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierItems.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierItemDto>.Failure("SupplierItem not found");
            }

            var dto = entity.Adapt<GetSupplierItemDto>();

            return Result<GetSupplierItemDto>.Success(dto, "SupplierItem retrieved successfully");
        }
    }

    public class GetSupplierItemByIdValidator : AbstractValidator<GetSupplierItemByIdQuery>
    {
        public GetSupplierItemByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
