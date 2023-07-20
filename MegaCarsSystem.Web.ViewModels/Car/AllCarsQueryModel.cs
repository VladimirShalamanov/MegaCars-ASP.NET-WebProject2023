namespace MegaCarsSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    using static Common.GeneralApplicationConstants;

    public class AllCarsQueryModel
    {
        public AllCarsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.CarsPerPage = EntitiesPerPage;

            this.Brands = new HashSet<string>();
            this.Engines = new HashSet<string>();
            this.Gearboxes = new HashSet<string>();
            this.Categories = new HashSet<string>();
            this.Cars = new HashSet<AllCarViewModel>();
        }

        public string? Brand { get; set; }

        public string? Engine { get; set; }

        public string? Gearbox { get; set; }

        public string? Category { get; set; }

        [Display(Name = "Search By Word")]
        public string? SearchString  { get; set; }

        [Display(Name = "Sort Cars by:")]
        public CarSorting CarSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Cars on Page:")]
        public int CarsPerPage { get; set; }

        public int TotalCars { get; set; }

        public IEnumerable<string> Brands { get; set; }

        public IEnumerable<string> Engines { get; set; }

        public IEnumerable<string> Gearboxes { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllCarViewModel> Cars { get; set; }
    }
}