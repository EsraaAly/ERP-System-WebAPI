using ERP.Domain.Enums;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemList : BaseEntity
    {
        
        public int ItemCategoryId { get; set; }

        public string ItemName { get; set; }

        public int UnitId { get; set; }
        
        public Unit Unit { get; set; }

        public ItemSales Sales { get; set; }

        public int MinimumLevel { get; set; }

        public int ItemOrder { get; set; }
        public ItemCategory ItemCategory { get; set; }

    }
}
