namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ItemCategoryBase
    {
        public string ItemCategoryName { get; set; } = string.Empty;
        public string AccNo { get; set; } = string.Empty;
        public string AccName { get; set; } = string.Empty;
    }

    public class AddItemCategoryDto : ItemCategoryBase
    {
    }

    public class GetItemCategoryDto : ItemCategoryBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateItemCategoryDto : ItemCategoryBase
    {
        public int Id { get; set; }
        public string ItemCategoryName { get; set; } = string.Empty;
        public string AccNo { get; set; } = string.Empty;
        public string AccName { get; set; } = string.Empty;
    }
}
