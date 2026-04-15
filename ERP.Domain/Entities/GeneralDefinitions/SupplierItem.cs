using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class SupplierItem : BaseEntity
    {
        
        public int SupplierId { get; set; }

        public int ItemCategoryId { get; set; }
        
        [ForeignKey("ItemCategoryId")]
        public ItemCategory ItemCategory { get; set; }

        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public ItemList ItemList { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
    }
}
