namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.UpdateClientType
{
    public class UpdateClientTypeCommand : IRequest<Result<GetClientTypeDto>>
    {
        public int id { get; set; }
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
            var entity = await _unitOfWork.ClientTypes.GetEntityByIdAsync(request.id);
            if (entity == null)
            {
                return Result<GetClientTypeDto>.Failure("ClientType not found");
            }

            entity.Type = request._updateClientTypeDTO.Type;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var IsUpdated = await _unitOfWork.ClientTypes.UpdateEntityAsync(entity);
            if (IsUpdated)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetClientTypeDto>();
                return Result<GetClientTypeDto>.Success(dto, "ClientType updated successfully");
            }

            return Result<GetClientTypeDto>.Failure("Failed to update ClientType");
        }
    }

    public class UpdateClientTypeValidator : AbstractValidator<UpdateClientTypeCommand>
    {
        public UpdateClientTypeValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateClientTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
