using ERP.Domain.Enums;

namespace ERP.Domain.Entities.GeneralDefinitions
{
    public class Client : BaseEntity
    {      
        public string FullName { get; set; }

        public string FullNameAr { get; set; }

        public string ClientType { get; set; }

        public string Supervisor { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public string Tele { get; set; }

        public string ReferenceNo { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public bool SpecialClient { get; set; }

        public decimal? CashLimit { get; set; }

        public string? PaymentTerms { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public int? CityId { get; set; }
        public City? City { get; set; }

        public string? AccNo { get; set; }

        public ClientStatus Status { get; set; }
        
        public List<ClientContact> Contacts { get; set; } = new List<ClientContact>();
        public List<ClientPriceList> PriceList { get; set; } = new List<ClientPriceList>();
    }
}
