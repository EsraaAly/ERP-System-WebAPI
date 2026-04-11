namespace ERP.Application.Features.GeneralDefinitions.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQuery : IRequest<Result<GetCountryDto>>
    {
        public int Id { get; set; }
    }

    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Result<GetCountryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCountryByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Countries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetCountryDto>.Failure("Country not found");
            }

            var dto = entity.Adapt<GetCountryDto>();

            return Result<GetCountryDto>.Success(dto, "Country retrieved successfully");
        }
    }

    public class GetCountryByIdValidator : AbstractValidator<GetCountryByIdQuery>
    {
        public GetCountryByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
