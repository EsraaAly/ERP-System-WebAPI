namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierItemBase
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int ItemCategoryId { get; set; }
        public string ItemName { get; set; } = string.Empty;
    }

    public class AddSupplierItemDto : SupplierItemBase
    {
    }

    public class GetSupplierItemDto : SupplierItemBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateSupplierItemDto : SupplierItemBase
    {
        public int Id { get; set; }
    }
}
