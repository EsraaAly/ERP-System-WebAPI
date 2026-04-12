namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Queries.GetSupplierTypeById
{
    public class GetSupplierTypeByIdQuery : IRequest<Result<GetSupplierTypeDto>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierTypeByIdHandler : IRequestHandler<GetSupplierTypeByIdQuery, Result<GetSupplierTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupplierTypeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierTypeDto>> Handle(GetSupplierTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierTypes.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierTypeDto>.Failure("SupplierType not found");
            }

            var dto = entity.Adapt<GetSupplierTypeDto>();

            return Result<GetSupplierTypeDto>.Success(dto, "SupplierType retrieved successfully");
        }
    }

    public class GetSupplierTypeByIdValidator : AbstractValidator<GetSupplierTypeByIdQuery>
    {
        public GetSupplierTypeByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
