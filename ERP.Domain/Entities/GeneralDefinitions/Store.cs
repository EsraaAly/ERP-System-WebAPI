using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class Store : BaseEntity
    {
        public string StoreName { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public int StoreCategoryId { get; set; }

        [ForeignKey("StoreCategoryId")]
        public virtual StoreCategory StoreCategory { get; set; }
    }
}
