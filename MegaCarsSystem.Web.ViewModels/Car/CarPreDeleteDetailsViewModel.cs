namespace MegaCarsSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    public class CarPreDeleteDetailsViewModel
    {
        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Display(Name = "Link for Image")]
        public string ImageUrl { get; set; } = null!;
    }
}