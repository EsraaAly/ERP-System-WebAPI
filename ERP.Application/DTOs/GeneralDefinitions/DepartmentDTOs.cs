namespace ERP.Application.DTOs.GeneralDefinitions
{
   
    public class DepartmentDto
    {
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNameAr { get; set; } = string.Empty;
    }

    // Create DTO
    public class AddDepartmentDto: DepartmentDto
    {
    }

    // Update DTO
    public class UpdateDepartmentDto: DepartmentDto
    {

    }

    // Get DTO
    public class GetDepartmentDto: DepartmentDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
