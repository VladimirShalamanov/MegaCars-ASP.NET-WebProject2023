namespace MegaCarsSystem.Web.ViewModels.Car
{
    using MegaCarsSystem.Web.ViewModels.Dealer;

    public class CarDetailsViewModel : AllCarViewModel
    {
        public int YearOfManufacture { get; set; }

        public int Horsepower { get; set; }

        public string Engine { get; set; } = null!;

        public string Gearbox { get; set; } = null!;

        public string Description { get; set; } = null!;
        
        public string Category { get; set; } = null!;
         
        public DealerInfoOnCarViewModel Dealer { get; set; } = null!;
    }
}