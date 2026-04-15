using System.ComponentModel.DataAnnotations;
using ERP.Domain.Enums;

namespace ERP.Application.DTOs.GeneralDefinitions
{
    public abstract class ClientBase
    {
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 100 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Arabic full name is required")]
        [StringLength(100, ErrorMessage = "Arabic full name cannot exceed 100 characters")]
        [Display(Name = "Full Name (Arabic)")]
        public string FullNameAr { get; set; } = string.Empty;

        [Required(ErrorMessage = "Client type is required")]
        [StringLength(50, ErrorMessage = "Client type cannot exceed 50 characters")]
        [Display(Name = "Client Type")]
        public string ClientType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Supervisor is required")]
        [StringLength(100, ErrorMessage = "Supervisor name cannot exceed 100 characters")]
        [Display(Name = "Supervisor")]
        public string Supervisor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string Tele { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reference number is required")]
        [StringLength(50, ErrorMessage = "Reference number cannot exceed 50 characters")]
        [Display(Name = "Reference Number")]
        public string ReferenceNo { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Longitude")]
        public string? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public string? Latitude { get; set; }

        [Display(Name = "Special Client")]
        public bool SpecialClient { get; set; }

        [Range(0, 999999999.99, ErrorMessage = "Cash limit must be between 0 and 999,999,999.99")]
        [Display(Name = "Cash Limit")]
        public decimal? CashLimit { get; set; }

        [StringLength(200, ErrorMessage = "Payment terms cannot exceed 200 characters")]
        [Display(Name = "Payment Terms")]
        public string? PaymentTerms { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        [Display(Name = "Account Number")]
        public string? AccNo { get; set; }

        [Display(Name = "Status")]
        public ClientStatus Status { get; set; }
    }

    public class AddClientDto : ClientBase
    {
        // Additional validation rules specific to Add operations
        [Compare("Email", ErrorMessage = "Email confirmation must match email")]
        [Display(Name = "Confirm Email")]
        public string? ConfirmEmail { get; set; }
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
        [Required(ErrorMessage = "Client ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Client ID must be a positive number")]
        public int Id { get; set; }
        
        // Override properties for update-specific validation
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 100 characters")]
        [Display(Name = "Full Name")]
        public new string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Arabic full name is required")]
        [StringLength(100, ErrorMessage = "Arabic full name cannot exceed 100 characters")]
        [Display(Name = "Full Name (Arabic)")]
        public new string FullNameAr { get; set; } = string.Empty;

        [Required(ErrorMessage = "Client type is required")]
        [StringLength(50, ErrorMessage = "Client type cannot exceed 50 characters")]
        [Display(Name = "Client Type")]
        public new string ClientType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Supervisor is required")]
        [StringLength(100, ErrorMessage = "Supervisor name cannot exceed 100 characters")]
        [Display(Name = "Supervisor")]
        public new string Supervisor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public new int RegionId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public new string Tele { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reference number is required")]
        [StringLength(50, ErrorMessage = "Reference number cannot exceed 50 characters")]
        [Display(Name = "Reference Number")]
        public new string ReferenceNo { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email Address")]
        public new string? Email { get; set; }

        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        [Display(Name = "Address")]
        public new string? Address { get; set; }

        [Display(Name = "Longitude")]
        public new string? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public new string? Latitude { get; set; }

        [Display(Name = "Special Client")]
        public new bool SpecialClient { get; set; }

        [Range(0, 999999999.99, ErrorMessage = "Cash limit must be between 0 and 999,999,999.99")]
        [Display(Name = "Cash Limit")]
        public new decimal? CashLimit { get; set; }

        [StringLength(200, ErrorMessage = "Payment terms cannot exceed 200 characters")]
        [Display(Name = "Payment Terms")]
        public new string? PaymentTerms { get; set; }

        [Display(Name = "Country")]
        public new int? CountryId { get; set; }

        [Display(Name = "City")]
        public new int? CityId { get; set; }

        [Display(Name = "Account Number")]
        public new string? AccNo { get; set; }

        [Display(Name = "Status")]
        public new ClientStatus Status { get; set; }
    }
}
