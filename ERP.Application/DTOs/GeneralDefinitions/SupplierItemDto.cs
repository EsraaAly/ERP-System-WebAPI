namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierItemBase
    {
        public int SupplierID { get; set; }
        public int ItemCategoryId { get; set; }
        public int ItemId { get; set; }
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
    }
}
