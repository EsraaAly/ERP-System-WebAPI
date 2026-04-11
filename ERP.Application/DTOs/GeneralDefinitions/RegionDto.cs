namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class RegionBase
    {
        public string RegionName { get; set; } = string.Empty;
    }

    public class AddRegionDto : RegionBase
    {
    }

    public class GetRegionDto : RegionBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateRegionDto : RegionBase
    {
        public int Id { get; set; }
        public string RegionName { get; set; } = string.Empty;
    }
}
