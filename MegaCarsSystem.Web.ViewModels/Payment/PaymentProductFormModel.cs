namespace MegaCarsSystem.Web.ViewModels.Payment
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentProductFormModel
    {
        [Required]
        string CheckEmail { get; set; } = null!;

        [Required]
        string FirstName { get; set; } = null!;

        [Required]
        string LastName { get; set; } = null!;

        [Required]
        string City { get; set; } = null!;

        [Required]
        string Address { get; set; } = null!;

        [Required]
        string PhoneNumber { get; set; } = null!;
    }
}