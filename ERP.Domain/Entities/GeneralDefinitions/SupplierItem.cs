namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class SupplierItem : BaseEntity
    {
        
        public int SupplierId { get; set; }

        public int ItemCategoryId { get; set; }
        
        public ItemCategory ItemCategory { get; set; }

        public int ItemId { get; set; }

        public ItemList ItemList { get; set; }

        public Supplier Supplier { get; set; }
    }
}
