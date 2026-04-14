namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemRegistry : BaseEntity
    {

        public int ItemId { get; set; }
        
        public ItemList Item { get; set; }

        public int ClientTypeId { get; set; }
        
        public ClientType ClientType { get; set; }

        public int RegionId { get; set; }
        
        public Region Region { get; set; }

        public decimal PriceWithoutVat { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public string Details { get; set; } = string.Empty;

        public int ItemOrder { get; set; }
        
        public int StoreId { get; set; }
        
        public Store Store { get; set; }

    }
}
