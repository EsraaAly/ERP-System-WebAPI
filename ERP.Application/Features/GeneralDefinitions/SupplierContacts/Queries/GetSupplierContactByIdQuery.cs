namespace ERP.Application.Features.GeneralDefinitions.SupplierContacts.Queries.GetSupplierContactById
{
    public class GetSupplierContactByIdQuery : IRequest<Result<GetSupplierContactDto>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierContactByIdHandler : IRequestHandler<GetSupplierContactByIdQuery, Result<GetSupplierContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupplierContactByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierContactDto>> Handle(GetSupplierContactByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierContacts.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierContactDto>.Failure("SupplierContact not found");
            }

            var dto = entity.Adapt<GetSupplierContactDto>();

            return Result<GetSupplierContactDto>.Success(dto, "SupplierContact retrieved successfully");
        }
    }

    public class GetSupplierContactByIdValidator : AbstractValidator<GetSupplierContactByIdQuery>
    {
        public GetSupplierContactByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
