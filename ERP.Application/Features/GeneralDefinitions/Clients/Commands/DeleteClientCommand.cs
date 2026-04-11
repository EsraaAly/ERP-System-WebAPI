namespace ERP.Application.Features.GeneralDefinitions.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Clients.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Client not found");
            }

            var deleted = await _unitOfWork.Clients.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Client deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Client");
        }
    }

    public class DeleteClientValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
