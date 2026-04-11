namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;
    }
}
