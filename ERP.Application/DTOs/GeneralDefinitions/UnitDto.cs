namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class UnitBase
    {
        public string UnitName { get; set; } = string.Empty;
    }

    public class AddUnitDto : UnitBase
    {
    }

    public class GetUnitDto : UnitBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateUnitDto : UnitBase
    {
        public int Id { get; set; }
        public string UnitName { get; set; } = string.Empty;
    }
}
