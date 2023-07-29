namespace MegaCarsSystem.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Dealer;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(PhoneNumber_MaxLength, MinimumLength = PhoneNumber_MinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}