namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ItemListBase
    {
        public string Category { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Sales { get; set; } = string.Empty;
        public int MinimumLevel { get; set; }
        public int ItemOrder { get; set; }
    }

    public class AddItemListDto : ItemListBase
    {
    }

    public class GetItemListDto : ItemListBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateItemListDto : ItemListBase
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Sales { get; set; } = string.Empty;
        public int MinimumLevel { get; set; }
        public int ItemOrder { get; set; }
    }
}
