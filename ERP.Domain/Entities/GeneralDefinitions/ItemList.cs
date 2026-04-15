using ERP.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemList : BaseEntity
    {
        
        public int ItemCategoryId { get; set; }
        [ForeignKey("ItemCategoryId")]
        public ItemCategory ItemCategory { get; set; }

        public string ItemName { get; set; }

        public int UnitId { get; set; }
        
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [Range(0, 1, ErrorMessage = "Sales must be 0 (No) or 1 (Yes).")]
        public ItemSales Sales { get; set; }

        public int MinimumLevel { get; set; }

        public int ItemOrder { get; set; }

    }
}
