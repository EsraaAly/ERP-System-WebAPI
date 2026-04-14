using ERP.Application.DTOs.GeneralDefinitions;

namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.AddClientType
{
    public class AddClientTypeCommand : IRequest<Result<GetClientTypeDto>>
    {
        public AddClientTypeDto _addClientTypeDTO { get; set; }
    }

    public class AddClientTypeHandler : IRequestHandler<AddClientTypeCommand, Result<GetClientTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetClientTypeDto>> Handle(AddClientTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addClientTypeDTO.Adapt<Domain.Entities.GeneralDefinitions.ClientType>();

            var addedEntity = await _unitOfWork.ClientTypes.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetClientTypeDto>();
                return Result<GetClientTypeDto>.Success(dto, "ClientType added successfully");
            }

            return Result<GetClientTypeDto>.Failure("Failed to add ClientType");
        }
    }

    public class AddClientTypeValidator : AbstractValidator<AddClientTypeCommand>
    {
        public AddClientTypeValidator()
        {
            RuleFor(x => x._addClientTypeDTO.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
