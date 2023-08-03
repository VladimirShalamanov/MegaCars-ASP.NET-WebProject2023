namespace MegaCarsSystem.Web.Areas.Admin.Controllers
{
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Areas.Admin.ViewModels.Car;
    using MegaCarsSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : BaseAdminController
    {
        private readonly IDealerService dealerService;
        private readonly ICarService carService;

        public CarController(
            IDealerService dealerService,
            ICarService carService)
        {
            this.dealerService = dealerService;
            this.carService = carService;
        }

        public async Task<IActionResult> Mine()
        {
            string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

            MyCarsViewModel viewModel = new MyCarsViewModel()
            {
                AddedCars = await this.carService.AllByDealerIdAsync(dealerId),
                RentedCars = await this.carService.AllByUserIdAsync(this.User.GetId()!)
            };

            return this.View(viewModel);
        }
    }
}