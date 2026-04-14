namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.UpdateSupplierType
{
    public class UpdateSupplierTypeCommand : IRequest<Result<GetSupplierTypeDto>>
    {
        public int Id { get; set; }
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
            var entity = await _unitOfWork.SupplierTypes.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetSupplierTypeDto>.Failure("SupplierType not found");
            }

            entity.Type = request._updateSupplierTypeDTO.Type;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.SupplierTypes.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetSupplierTypeDto>();
                return Result<GetSupplierTypeDto>.Success(dto, "SupplierType updated successfully");
            }

            return Result<GetSupplierTypeDto>.Failure("Failed to update SupplierType");
        }
    }

    public class UpdateSupplierTypeValidator : AbstractValidator<UpdateSupplierTypeCommand>
    {
        public UpdateSupplierTypeValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateSupplierTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
