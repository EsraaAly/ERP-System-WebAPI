namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class StoreCategory : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;

        public virtual ICollection<Store> Stores { get; set; }
    }
}
