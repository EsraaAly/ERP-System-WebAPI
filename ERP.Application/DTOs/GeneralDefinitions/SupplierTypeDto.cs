namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierTypeBase
    {
        public string Type { get; set; } = string.Empty;
    }

    public class AddSupplierTypeDto : SupplierTypeBase
    {
    }

    public class GetSupplierTypeDto : SupplierTypeBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateSupplierTypeDto : SupplierTypeBase
    {
    }
}
