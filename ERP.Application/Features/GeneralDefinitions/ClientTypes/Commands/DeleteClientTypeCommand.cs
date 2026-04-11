namespace ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.DeleteClientType
{
    public class DeleteClientTypeCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientTypeHandler : IRequestHandler<DeleteClientTypeCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteClientTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientTypes.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ClientType not found");
            }

            var deleted = await _unitOfWork.ClientTypes.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ClientType deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ClientType");
        }
    }

    public class DeleteClientTypeValidator : AbstractValidator<DeleteClientTypeCommand>
    {
        public DeleteClientTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
