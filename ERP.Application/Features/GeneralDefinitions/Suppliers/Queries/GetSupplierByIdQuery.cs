namespace ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<Result<GetSupplierDto>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, Result<GetSupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupplierByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Suppliers.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierDto>.Failure("Supplier not found");
            }

            var dto = entity.Adapt<GetSupplierDto>();

            return Result<GetSupplierDto>.Success(dto, "Supplier retrieved successfully");
        }
    }

    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
