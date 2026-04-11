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
            var entity = new Domain.Entities.GeneralDefinitions.Unit
            {
                UnitName = request._addUnitDTO.UnitName,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.Unit.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetUnitDto>();
                await _unitOfWork.CommitAsync();
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
