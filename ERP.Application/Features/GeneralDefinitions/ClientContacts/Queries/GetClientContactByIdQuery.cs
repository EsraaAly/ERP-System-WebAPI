namespace ERP.Application.Features.GeneralDefinitions.ClientContacts.Queries.GetClientContactById
{
    public class GetClientContactByIdQuery : IRequest<Result<GetClientContactDto>>
    {
        public int Id { get; set; }
    }

    public class GetClientContactByIdHandler : IRequestHandler<GetClientContactByIdQuery, Result<GetClientContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientContactByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientContactDto>> Handle(GetClientContactByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientContacts.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetClientContactDto>.Failure("ClientContact not found");
            }

            var dto = entity.Adapt<GetClientContactDto>();

            return Result<GetClientContactDto>.Success(dto, "ClientContact retrieved successfully");
        }
    }

    public class GetClientContactByIdValidator : AbstractValidator<GetClientContactByIdQuery>
    {
        public GetClientContactByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
