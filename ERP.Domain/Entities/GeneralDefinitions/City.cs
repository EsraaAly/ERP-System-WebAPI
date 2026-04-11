namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class City : BaseEntity
    {
        public string CityName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
