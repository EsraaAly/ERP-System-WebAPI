namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ItemRegistryBase
    {
        public int ItemId { get; set; }
        public int ClientTypeId { get; set; }
        public int RegionId { get; set; }
        public decimal PriceWithoutVat { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public string Details { get; set; } = string.Empty;
        public int ItemOrder { get; set; }
        public int StoreId { get; set; }
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
    }
}
