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
            var entity = request._addSupplierTypeDTO.Adapt<Domain.Entities.GeneralDefinitions.SupplierType>();

            var addedEntity = await _unitOfWork.SupplierTypes.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetSupplierTypeDto>();
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
