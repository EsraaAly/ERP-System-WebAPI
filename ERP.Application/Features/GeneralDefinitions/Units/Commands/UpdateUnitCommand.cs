namespace ERP.Application.Features.GeneralDefinitions.Units.Commands.UpdateUnit
{
    public class UpdateUnitCommand : IRequest<Result<GetUnitDto>>
    {
        public UpdateUnitDto _updateUnitDTO { get; set; }
    }

    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, Result<GetUnitDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetUnitDto>> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Unit.GetEntityByIdAsync(request._updateUnitDTO.Id);
            if (entity == null)
            {
                return Result<GetUnitDto>.Failure("Unit not found");
            }

            entity.UnitName = request._updateUnitDTO.UnitName;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.Unit.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetUnitDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetUnitDto>.Success(dto, "Unit updated successfully");
            }

            return Result<GetUnitDto>.Failure("Failed to update Unit");
        }
    }

    public class UpdateUnitValidator : AbstractValidator<UpdateUnitCommand>
    {
        public UpdateUnitValidator()
        {
            RuleFor(x => x._updateUnitDTO.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateUnitDTO.UnitName).NotEmpty().WithMessage("UnitName is required");
        }
    }
}
