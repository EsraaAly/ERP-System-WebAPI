namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class SupplierItem : BaseEntity
    {
        
        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public int ItemCategoryId { get; set; }
        
        public ItemCategory ItemCategory { get; set; }

        public string ItemName { get; set; }

        public Supplier Supplier { get; set; }
    }
}
