namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemRegistry : BaseEntity
    {
        public string ItemCategory { get; set; } = string.Empty;

        public string ItemName { get; set; } = string.Empty;

        public string ClientType { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public decimal PriceWithoutVat { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public string Details { get; set; } = string.Empty;

        public int ItemOrder { get; set; }

    }
}
