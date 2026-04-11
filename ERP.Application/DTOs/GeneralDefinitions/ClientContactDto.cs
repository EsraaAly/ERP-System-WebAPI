namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ClientContactBase
    {
        public int ClientID { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tele { get; set; } = string.Empty;
    }

    public class AddClientContactDto : ClientContactBase
    {
    }

    public class GetClientContactDto : ClientContactBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateClientContactDto : ClientContactBase
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tele { get; set; } = string.Empty;
    }
}
