namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class StoreCategoryBase
    {
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
    }

    public class AddStoreCategoryDto : StoreCategoryBase
    {
    }

    public class GetStoreCategoryDto : StoreCategoryBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateStoreCategoryDto : StoreCategoryBase
    {
    }
}
