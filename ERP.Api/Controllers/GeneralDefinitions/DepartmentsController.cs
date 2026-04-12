namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class DepartmentsController : BaseController
    {
        public DepartmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(ApiRoutes.GeneralDefinitions.Departments.AddDepartment)]
        public async Task<IActionResult> CreateDepartment([FromBody] AddDepartmentDto departmentDto)
        {
            var command = new AddDepartmentCommand { _addDepartmentDTO = departmentDto };
            return await HandleCommand<AddDepartmentCommand, GetDepartmentDto>(command);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Departments.GetDepartmentById + "/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var query = new GetDepartmentByIdQuery { Id = id };
            return await HandleQueryWithData<GetDepartmentByIdQuery, GetDepartmentDto>(query);
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Departments.GetAllDepartments)]
        public async Task<IActionResult> GetAllDepartments()
        {
            var query = new GetAllDepartmentsQuery();
            return await HandleQueryWithData<GetAllDepartmentsQuery, List<GetDepartmentDto>>(query);
        }

        [HttpPut(ApiRoutes.GeneralDefinitions.Departments.UpdateDepartment + "/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto departmentDto)
        {
            var command = new UpdateDepartmentCommand { _updateDepartmentDTO = departmentDto, id = id };
            return await HandleCommand<UpdateDepartmentCommand, GetDepartmentDto>(command);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Departments.DeleteDepartment + "/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var command = new DeleteDepartmentCommand { Id = id };
            return await HandleCommand<DeleteDepartmentCommand, bool>(command);
        }
    }
}
