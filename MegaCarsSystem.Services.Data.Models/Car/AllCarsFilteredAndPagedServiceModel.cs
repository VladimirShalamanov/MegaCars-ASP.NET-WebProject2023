namespace MegaCarsSystem.Services.Data.Models.Car
{
    using MegaCarsSystem.Web.ViewModels.Car;

    public class AllCarsFilteredAndPagedServiceModel
    {
        public AllCarsFilteredAndPagedServiceModel()
        {
            this.Cars = new HashSet<AllCarViewModel>();
        }
        public int TotalCarsCount { get; set; }

        public IEnumerable<AllCarViewModel> Cars { get; set; }
    }
}