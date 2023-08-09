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
        public string CheckEmail { get; set; } = null!;

        [Required]
        [StringLength(City_MaxLength, MinimumLength = City_MinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(Address_MaxLength, MinimumLength = Address_MinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumber_MaxLength, MinimumLength = PhoneNumber_MinLength)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public string? PromoCode { get; set; }
    }
}