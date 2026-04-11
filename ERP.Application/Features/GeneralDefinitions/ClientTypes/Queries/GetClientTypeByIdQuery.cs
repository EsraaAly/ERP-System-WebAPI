namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Queries.GetClientTypeById
{
    public class GetClientTypeByIdQuery : IRequest<Result<GetClientTypeDto>>
    {
        public int Id { get; set; }
    }

    public class GetClientTypeByIdHandler : IRequestHandler<GetClientTypeByIdQuery, Result<GetClientTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientTypeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientTypeDto>> Handle(GetClientTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientTypes.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetClientTypeDto>.Failure("ClientType not found");
            }

            var dto = entity.Adapt<GetClientTypeDto>();

            return Result<GetClientTypeDto>.Success(dto, "ClientType retrieved successfully");
        }
    }

    public class GetClientTypeByIdValidator : AbstractValidator<GetClientTypeByIdQuery>
    {
        public GetClientTypeByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
