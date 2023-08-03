namespace MegaCarsSystem.Web.Areas.Admin.ViewModels.Car
{
    using MegaCarsSystem.Web.ViewModels.Car;

    public class MyCarsViewModel
    {
        public IEnumerable<AllCarViewModel> AddedCars { get; set; } = null!;

        public IEnumerable<AllCarViewModel> RentedCars { get; set; } = null!;
    }
}