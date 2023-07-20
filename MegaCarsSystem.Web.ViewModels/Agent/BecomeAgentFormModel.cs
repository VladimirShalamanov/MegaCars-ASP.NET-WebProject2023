namespace MegaCarsSystem.Web.ViewModels.Agent
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Agent;

    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumber_MaxLength, MinimumLength = PhoneNumber_MinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}