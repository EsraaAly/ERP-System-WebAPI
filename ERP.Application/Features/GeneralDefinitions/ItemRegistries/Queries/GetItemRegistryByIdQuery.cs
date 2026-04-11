namespace ERP.Application.Features.GeneralDefinitions.ItemRegistries.Queries.GetItemRegistryById
{
    public class GetItemRegistryByIdQuery : IRequest<Result<GetItemRegistryDto>>
    {
        public int Id { get; set; }
    }

    public class GetItemRegistryByIdHandler : IRequestHandler<GetItemRegistryByIdQuery, Result<GetItemRegistryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetItemRegistryByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetItemRegistryDto>> Handle(GetItemRegistryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ItemRegistries.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetItemRegistryDto>.Failure("ItemRegistry not found");
            }

            var dto = entity.Adapt<GetItemRegistryDto>();

            return Result<GetItemRegistryDto>.Success(dto, "ItemRegistry retrieved successfully");
        }
    }

    public class GetItemRegistryByIdValidator : AbstractValidator<GetItemRegistryByIdQuery>
    {
        public GetItemRegistryByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
