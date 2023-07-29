namespace MegaCarsSystem.Web.ViewModels.Dealer
{
    using System.ComponentModel.DataAnnotations;

    public class DealerInfoOnCarViewModel
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}