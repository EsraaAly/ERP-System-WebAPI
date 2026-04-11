namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ItemList : BaseEntity
    {
        
        public string Category { get; set; }

        public string ItemName { get; set; }

        public string Unit { get; set; }

        public string Sales { get; set; }

        public int MinimumLevel { get; set; }

        public int ItemOrder { get; set; }

    }
}
