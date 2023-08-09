namespace MegaCarsSystem.Web.ViewModels.Payment
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.PaymentProduct;

    public class PaymentProductFormModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "We need to Check your Email again")]
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

        [Display(Name = "Do you have a Promo Code?")]
        public string? PromoCode { get; set; }
    }
}