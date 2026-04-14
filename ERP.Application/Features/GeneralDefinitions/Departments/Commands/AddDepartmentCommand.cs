namespace ERP.Application.Features.GeneralDefinitions.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommand : IRequest<Result<GetDepartmentDto>>
    {
        public AddDepartmentDto _addDepartmentDTO { get; set; }
    }

    public class AddDepartmentHandler : IRequestHandler<AddDepartmentCommand, Result<GetDepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetDepartmentDto>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = request._addDepartmentDTO.Adapt<Domain.Entities.GeneralDefinitions.Department>();

            var addedEntity = await _unitOfWork.Departments.AddEntityAsync(entity);
            if (addedEntity != null)
            {
                
                await _unitOfWork.CommitAsync();
                var dto = addedEntity.Adapt<GetDepartmentDto>();
                return Result<GetDepartmentDto>.Success(dto, "Department added successfully");
            }

            return Result<GetDepartmentDto>.Failure("Failed to add Department");
        }
    }

    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentValidator()
        {
            RuleFor(x => x._addDepartmentDTO.DepartmentName).NotEmpty().WithMessage("DepartmentName is required");
            RuleFor(x => x._addDepartmentDTO.DepartmentNameAr).NotEmpty().WithMessage("DepartmentNameAr is required");
        }
    }
}
