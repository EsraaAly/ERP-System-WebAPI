namespace ERP.Application.Features.GeneralDefinitions.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<Result<List<GetDepartmentDto>>>
    {
    }

    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, Result<List<GetDepartmentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDepartmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetDepartmentDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Departments.GetAllEntitytiesAsync();
            var dtos = entities.Adapt<List<GetDepartmentDto>>();

            return Result<List<GetDepartmentDto>>.Success(dtos, "Departments retrieved successfully");
        }
    }
}
