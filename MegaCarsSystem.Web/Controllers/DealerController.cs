namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using MegaCarsSystem.Web.ViewModels.Dealer;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;

    [Authorize]
    public class DealerController : Controller
    {
        private readonly IDealerService dealerService;

        public DealerController(IDealerService dealerService)
        {
            this.dealerService = dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(userId!);

            if (isDealer)
            {
                this.TempData[ErrorMessage] = "You are already an Dealer!";

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerFormModel model)
        {
            string? userId = this.User.GetId();
            bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(userId!);

            if (isDealer)
            {
                this.TempData[ErrorMessage] = "You are already an Dealer!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.dealerService.DealerExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Dealer with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasActiveRents = await this.dealerService.HasRentsByUserIdAsync(userId!);

            if (userHasActiveRents)
            {
                this.TempData[ErrorMessage] = "You must not have any active rents in order to become an Dealer!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                await this.dealerService.Create(userId!, model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            return this.RedirectToAction("All", "Car");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}