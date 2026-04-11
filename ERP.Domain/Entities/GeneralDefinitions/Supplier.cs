namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }

        public string NameAr { get; set; }

        public string SupplierType { get; set; }

        public string SupplierCountry { get; set; }

        public string Telephone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Remarks { get; set; }

        public string CR { get; set; }

        public string VATNo { get; set; }

        public string AccNo { get; set; }

        public List<SupplierContact> Contacts { get; set; } = new List<SupplierContact>();
        public List<SupplierItem> Items { get; set; } = new List<SupplierItem>();
    }
}
