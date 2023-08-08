namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;

    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IShopCartService shopCartService;

        public PaymentController(IShopCartService shopCartService)
        {
            this.shopCartService = shopCartService;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentProduct()
        {
            // check shop cart, item, user
            // add errors
            // END view page order



            bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isDealer)
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to add new cars!";

                return RedirectToAction("Become", "Dealer");
            }

            try
            {
                CarFormModel carModel = new CarFormModel()
                {
                    Engines = await this.engineService.GetAllEnginesAsync(),
                    Gearboxes = await this.gearboxService.GetAllGearboxesAsync(),
                    Categories = await this.categoryService.GetAllCategoriesAsync()
                };

                return View(carModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}