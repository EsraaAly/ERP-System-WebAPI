namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ClientTypeBase
    {
        public string Type { get; set; } = string.Empty;
    }

    public class AddClientTypeDto : ClientTypeBase
    {
    }

    public class GetClientTypeDto : ClientTypeBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateClientTypeDto : ClientTypeBase
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
