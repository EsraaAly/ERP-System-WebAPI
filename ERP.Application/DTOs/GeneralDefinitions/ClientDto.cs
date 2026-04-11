namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ClientBase
    {
        public string FullName { get; set; } = string.Empty;
        public string FullNameAr { get; set; } = string.Empty;
        public string ClientType { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Tele { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public bool SpecialClient { get; set; }
        public decimal CashLimit { get; set; }
        public string PaymentTerms { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string AccNo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class AddClientDto : ClientBase
    {
    }

    public class GetClientDto : ClientBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateClientDto : ClientBase
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FullNameAr { get; set; } = string.Empty;
        public string ClientType { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Tele { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public bool SpecialClient { get; set; }
        public decimal CashLimit { get; set; }
        public string PaymentTerms { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string AccNo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
