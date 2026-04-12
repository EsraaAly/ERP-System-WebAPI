namespace ERP.Application.Features.GeneralDefinitions.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<Result<GetDepartmentDto>>
    {
        public int Id { get; set; }
    }

    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Result<GetDepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDepartmentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetDepartmentDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Departments.GetEntityByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GetDepartmentDto>.Failure("Department not found");
            }

            var dto = entity.Adapt<GetDepartmentDto>();
            return Result<GetDepartmentDto>.Success(dto, "Department retrieved successfully");
        }
    }
}
