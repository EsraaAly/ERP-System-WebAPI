namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.UpdateClientType
{
    public class UpdateClientTypeCommand : IRequest<Result<GetClientTypeDto>>
    {
        public UpdateClientTypeDto _updateClientTypeDTO { get; set; }
    }

    public class UpdateClientTypeHandler : IRequestHandler<UpdateClientTypeCommand, Result<GetClientTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientTypeDto>> Handle(UpdateClientTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientTypes.GetEntityByIdAsync(request._updateClientTypeDTO.Id);
            if (entity == null)
            {
                return Result<GetClientTypeDto>.Failure("ClientType not found");
            }

            entity.Type = request._updateClientTypeDTO.Type;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.ClientTypes.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                var dto = updatedEntity.Adapt<GetClientTypeDto>();
                await _unitOfWork.CommitAsync();
                return Result<GetClientTypeDto>.Success(dto, "ClientType updated successfully");
            }

            return Result<GetClientTypeDto>.Failure("Failed to update ClientType");
        }
    }

    public class UpdateClientTypeValidator : AbstractValidator<UpdateClientTypeCommand>
    {
        public UpdateClientTypeValidator()
        {
            RuleFor(x => x._updateClientTypeDTO.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
