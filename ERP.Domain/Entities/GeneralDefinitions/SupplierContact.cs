namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class SupplierContact : BaseEntity
    {
        
        public int SupplierID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public Supplier Supplier { get; set; }
    }
}
