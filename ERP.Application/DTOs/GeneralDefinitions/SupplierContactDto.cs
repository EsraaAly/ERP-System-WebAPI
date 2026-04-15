namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierContactBase
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }

    public class AddSupplierContactDto : SupplierContactBase
    {
    }

    public class GetSupplierContactDto : SupplierContactBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateSupplierContactDto : SupplierContactBase
    {
        public int Id { get; set; }
    }
}
