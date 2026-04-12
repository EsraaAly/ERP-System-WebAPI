namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class SupplierType : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
