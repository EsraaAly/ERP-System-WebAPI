using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemRegistry : BaseEntity
    {

        public int ItemId { get; set; }
        
        [ForeignKey("ItemId")]
        public ItemList Item { get; set; }

        public int ClientTypeId { get; set; }
        
        [ForeignKey("ClientTypeId")]
        public ClientType ClientType { get; set; }

        public int RegionId { get; set; }
        
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public decimal PriceWithoutVat { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public string Details { get; set; } = string.Empty;

        public int ItemOrder { get; set; }
        
        public int StoreId { get; set; }
        
        [ForeignKey("StoreId")]
        public Store Store { get; set; }

    }
}
