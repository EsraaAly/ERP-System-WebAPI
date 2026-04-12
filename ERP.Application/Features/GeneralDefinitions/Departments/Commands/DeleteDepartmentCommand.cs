namespace ERP.Application.Features.GeneralDefinitions.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Departments.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.Failure("Department not found");
            }

            var deletedEntity = await _unitOfWork.Departments.DeleteEntityAsync(entity.Id);
            if (deletedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                return Result<bool>.Success(true, "Department deleted successfully");
            }

            return Result<bool>.Failure("Failed to delete Department");
        }
    }

    public class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
