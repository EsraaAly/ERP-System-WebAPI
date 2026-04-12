namespace ERP.Application.Features.GeneralDefinitions.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<Result<GetClientDto>>
    {
        public int Id { get; set; }
    }

    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Result<GetClientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Clients.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetClientDto>.Failure("Client not found");
            }

            var dto = entity.Adapt<GetClientDto>();

            return Result<GetClientDto>.Success(dto, "Client retrieved successfully");
        }
    }

    public class GetClientByIdValidator : AbstractValidator<GetClientByIdQuery>
    {
        public GetClientByIdValidator()
        {
                        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").NotEqual(0).WithMessage("Id cannot be zero").GreaterThan(0).WithMessage("Id must be positive");
        }
    }
}
