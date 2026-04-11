namespace ERP.Application.Features.GeneralDefinitions.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery : IRequest<Result<GetCityDto>>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, Result<GetCityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCityByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Cities.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetCityDto>.Failure("City not found");
            }

            var dto = entity.Adapt<GetCityDto>();

            return Result<GetCityDto>.Success(dto, "City retrieved successfully");
        }
    }

    public class GetCityByIdValidator : AbstractValidator<GetCityByIdQuery>
    {
        public GetCityByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
