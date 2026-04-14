namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ClientPriceList : BaseEntity
    {
        public int ClientID { get; set; }

        public int ItemSNo { get; set; }

        public int ItemCategoryId { get; set; }
        
        public ItemCategory ItemCategory { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public decimal PriceWithoutVat { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public Client Client { get; set; }
    }
}
