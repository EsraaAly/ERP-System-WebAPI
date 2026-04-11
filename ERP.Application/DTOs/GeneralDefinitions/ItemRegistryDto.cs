namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ItemRegistryBase
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

    public class AddItemRegistryDto : ItemRegistryBase
    {
    }

    public class GetItemRegistryDto : ItemRegistryBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateItemRegistryDto : ItemRegistryBase
    {
        public int Id { get; set; }
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
