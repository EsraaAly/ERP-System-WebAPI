namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierBase
    {
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public int SupplierTypeId { get; set; }
        public int CountryId { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string CR { get; set; } = string.Empty;
        public string VATNo { get; set; } = string.Empty;
        public string AccNo { get; set; } = string.Empty;
    }

    public class AddSupplierDto : SupplierBase
    {
    }

    public class GetSupplierDto : SupplierBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateSupplierDto : SupplierBase
    {

    }
}
