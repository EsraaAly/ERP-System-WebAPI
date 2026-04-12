namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.UpdateSupplierType
{
    public class UpdateSupplierTypeCommand : IRequest<Result<GetSupplierTypeDto>>
    {
        public UpdateSupplierTypeDto _updateSupplierTypeDTO { get; set; }
    }

    public class UpdateSupplierTypeHandler : IRequestHandler<UpdateSupplierTypeCommand, Result<GetSupplierTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierTypeDto>> Handle(UpdateSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SupplierTypes.GetEntityByIdAsync(request._updateSupplierTypeDTO.Id);
            if (entity == null)
            {
                return Result<GetSupplierTypeDto>.Failure("SupplierType not found");
            }

            entity.Type = request._updateSupplierTypeDTO.Type;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.SupplierTypes.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetSupplierTypeDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierTypeDto>.Success(dto, "SupplierType updated successfully");
            }

            return Result<GetSupplierTypeDto>.Failure("Failed to update SupplierType");
        }
    }

    public class UpdateSupplierTypeValidator : AbstractValidator<UpdateSupplierTypeCommand>
    {
        public UpdateSupplierTypeValidator()
        {
            RuleFor(x => x._updateSupplierTypeDTO.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
