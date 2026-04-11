namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemCategory : BaseEntity
    {
        public string ItemCategoryName { get; set; } = string.Empty;

        public string AccNo { get; set; } = string.Empty;

        public string AccName { get; set; } = string.Empty;
    }
}
