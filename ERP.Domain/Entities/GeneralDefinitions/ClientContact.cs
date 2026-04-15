using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class ClientContact : BaseEntity
    {
        public int ClientId { get; set; }

        public string ContactName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Tele { get; set; } = string.Empty;


        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
