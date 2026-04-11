namespace ERP.Application.Features.GeneralDefinitions.Units.Queries.GetUnitById
{
    public class GetUnitByIdQuery : IRequest<Result<GetUnitDto>>
    {
        public int Id { get; set; }
    }

    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, Result<GetUnitDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUnitByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetUnitDto>> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Unit.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetUnitDto>.Failure("Unit not found");
            }

            var dto = entity.Adapt<GetUnitDto>();

            return Result<GetUnitDto>.Success(dto, "Unit retrieved successfully");
        }
    }

    public class GetUnitByIdValidator : AbstractValidator<GetUnitByIdQuery>
    {
        public GetUnitByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
