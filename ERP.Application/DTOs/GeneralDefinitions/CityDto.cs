namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class CityBase
    {
        public string CityName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class AddCityDto : CityBase
    {
    }

    public class GetCityDto : CityBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateCityDto : CityBase
    {
    }
}
