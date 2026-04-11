namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ClientContact : BaseEntity
    {
        public int ClientID { get; set; }

        public string ContactName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Tele { get; set; } = string.Empty;


        public Client Client { get; set; }
    }
}
