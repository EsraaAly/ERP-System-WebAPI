namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ClientPriceList : BaseEntity
    {
        public int ClientId { get; set; }

        public int ItemId { get; set; }

        public int ItemCategoryId { get; set; }
        
        public ItemCategory ItemCategory { get; set; }

        public ItemList ItemList { get; set; }

        public decimal PriceWithoutVat { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public Client Client { get; set; }
    }
}
