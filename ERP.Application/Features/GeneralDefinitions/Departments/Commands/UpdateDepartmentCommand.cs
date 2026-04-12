namespace ERP.Application.Features.GeneralDefinitions.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Result<GetDepartmentDto>>
    {
        public int id { get; set; }
        public UpdateDepartmentDto _updateDepartmentDTO { get; set; }
    }

    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Result<GetDepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetDepartmentDto>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Departments.GetEntityByIdAsync(request.id);
            if (entity == null)
            {
                return Result<GetDepartmentDto>.Failure("Department not found");
            }

            entity.DepartmentName = request._updateDepartmentDTO.DepartmentName;
            entity.DepartmentNameAr = request._updateDepartmentDTO.DepartmentNameAr;
            entity.UpdatedBy = "System";
            entity.UpdatedDate = DateTime.UtcNow;

            var updatedEntity = await _unitOfWork.Departments.UpdateEntityAsync(entity);
            if (updatedEntity != null)
            {
                await _unitOfWork.CommitAsync();
                var dto = entity.Adapt<GetDepartmentDto>();
                return Result<GetDepartmentDto>.Success(dto, "Department updated successfully");
            }

            return Result<GetDepartmentDto>.Failure("Failed to update Department");
        }
    }

    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x._updateDepartmentDTO.DepartmentName).NotEmpty().WithMessage("DepartmentName is required");
            RuleFor(x => x._updateDepartmentDTO.DepartmentNameAr).NotEmpty().WithMessage("DepartmentNameAr is required");
        }
    }
}
