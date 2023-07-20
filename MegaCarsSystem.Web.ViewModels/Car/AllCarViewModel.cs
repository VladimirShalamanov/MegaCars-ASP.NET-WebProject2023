namespace MegaCarsSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    public class AllCarViewModel
    {
        public string Id { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Display(Name = "Link for Image")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}