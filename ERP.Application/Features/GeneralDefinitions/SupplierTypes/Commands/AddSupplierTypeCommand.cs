namespace ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.AddSupplierType
{
    public class AddSupplierTypeCommand : IRequest<Result<GetSupplierTypeDto>>
    {
        public AddSupplierTypeDto _addSupplierTypeDTO { get; set; }
    }

    public class AddSupplierTypeHandler : IRequestHandler<AddSupplierTypeCommand, Result<GetSupplierTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSupplierTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSupplierTypeDto>> Handle(AddSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.GeneralDefinitions.SupplierType
            {
                Type = request._addSupplierTypeDTO.Type,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            var addedEntity = await _unitOfWork.SupplierTypes.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                var dto = addedEntity.Adapt<GetSupplierTypeDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetSupplierTypeDto>.Success(dto, "SupplierType added successfully");
            }

            return Result<GetSupplierTypeDto>.Failure("Failed to add SupplierType");
        }
    }

    public class AddSupplierTypeValidator : AbstractValidator<AddSupplierTypeCommand>
    {
        public AddSupplierTypeValidator()
        {
            RuleFor(x => x._addSupplierTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
