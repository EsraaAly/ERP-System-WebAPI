namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ClientPriceListBase
    {
        public int ClientID { get; set; }
        public int ItemSNo { get; set; }
        public string ItemCategory { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public decimal PriceWithoutVat { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }

    public class AddClientPriceListDto : ClientPriceListBase
    {
    }

    public class GetClientPriceListDto : ClientPriceListBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateClientPriceListDto : ClientPriceListBase
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int ItemSNo { get; set; }
        public string ItemCategory { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public decimal PriceWithoutVat { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }
}
