namespace MegaCarsSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ApplicationUser;

    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(Password_MaxLength, MinimumLength = Password_MinLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstName_MaxLength, MinimumLength = FirstName_MinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastName_MaxLength, MinimumLength = LastName_MinLength)]
        public string LastName { get; set; } = null!;
    }
}
