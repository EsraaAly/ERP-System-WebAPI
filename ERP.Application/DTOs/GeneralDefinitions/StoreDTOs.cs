namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class StoreBase
    {
        public string StoreName { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public int StoreCategoryId { get; set; }
    }

    public class AddStoreDto : StoreBase
    {
    }

    public class GetStoreDto : StoreBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateStoreDto : StoreBase
    {
    }
}
