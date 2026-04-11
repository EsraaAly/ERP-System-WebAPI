namespace ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.DeleteClientContact
{
    public class DeleteClientContactCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientContactHandler : IRequestHandler<DeleteClientContactCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientContactHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteClientContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientContacts.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("ClientContact not found");
            }

            var deleted = await _unitOfWork.ClientContacts.DeleteEntityAsync(request.Id);
            if (deleted)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "ClientContact deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete ClientContact");
        }
    }

    public class DeleteClientContactValidator : AbstractValidator<DeleteClientContactCommand>
    {
        public DeleteClientContactValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
