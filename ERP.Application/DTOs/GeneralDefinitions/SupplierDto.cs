namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class SupplierBase
    {
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public int SupplierTypeId { get; set; }
        public int CountryId { get; set; }
        public string? Telephone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Remarks { get; set; } = string.Empty;
        public string? CR { get; set; } = string.Empty;
        public string? VATNo { get; set; } = string.Empty;
        public string? AccNo { get; set; } = string.Empty;


    }

    public class AddSupplierDto : SupplierBase
    {
        public List<AddSupplierContactDto> Contacts { get; set; } = new List<AddSupplierContactDto>();
        public List<AddSupplierItemDto> Items { get; set; } = new List<AddSupplierItemDto>();
    }

    public class GetSupplierDto : SupplierBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<GetSupplierContactDto> Contacts { get; set; } = new List<GetSupplierContactDto>();
        public List<GetSupplierItemDto> Items { get; set; } = new List<GetSupplierItemDto>();
    }

    public class UpdateSupplierDto : SupplierBase
    {
        public List<UpdateSupplierContactDto> Contacts { get; set; } = new List<UpdateSupplierContactDto>();
        public List<UpdateSupplierItemDto> Items { get; set; } = new List<UpdateSupplierItemDto>();
    }
}
