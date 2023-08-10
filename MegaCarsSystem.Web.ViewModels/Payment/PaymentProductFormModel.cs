namespace MegaCarsSystem.Web.ViewModels.Payment
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.PaymentProduct;

    public class PaymentProductFormModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Checking Email")]
        public string CheckEmail { get; set; } = null!;

        [Required]
        [StringLength(City_MaxLength, MinimumLength = City_MinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(Address_MaxLength, MinimumLength = Address_MinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(PhoneNumber_MaxLength, MinimumLength = PhoneNumber_MinLength)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public decimal Discount { get; set; }

        [Required]
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; } = null!;
    }
}