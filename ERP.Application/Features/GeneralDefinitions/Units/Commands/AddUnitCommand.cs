namespace ERP.Application.Features.GeneralDefinitions.Units.Commands.AddUnit
{
    public class AddUnitCommand : IRequest<Result<GetUnitDto>>
    {
        public AddUnitDto _addUnitDTO { get; set; }
    }

    public class AddUnitHandler : IRequestHandler<AddUnitCommand, Result<GetUnitDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUnitHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetUnitDto>> Handle(AddUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addUnitDTO.Adapt<Domain.Entities.GeneralDefinitions.Unit>();

            var addedEntity = await _unitOfWork.Unit.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetUnitDto>();
                return Result<GetUnitDto>.Success(dto, "Unit added successfully");
            }

            return Result<GetUnitDto>.Failure("Failed to add Unit");
        }
    }

    public class AddUnitValidator : AbstractValidator<AddUnitCommand>
    {
        public AddUnitValidator()
        {
            RuleFor(x => x._addUnitDTO.UnitName).NotEmpty().WithMessage("UnitName is required");
        }
    }
}
