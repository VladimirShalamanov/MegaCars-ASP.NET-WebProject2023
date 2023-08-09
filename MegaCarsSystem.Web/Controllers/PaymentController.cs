namespace MegaCarsSystem.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using ViewModels.Payment;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationsMessagesConstants;

    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly IShopCartService shopCartService;
        private readonly IUserService userService;

        public PaymentController(
            IPaymentService paymentService,
            IShopCartService shopCartService,
            IUserService userService)
        {
            this.paymentService = paymentService;
            this.shopCartService = shopCartService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentProduct()
        {
            string fullNameUser = await this.userService.GetFullNameByIdAsync(this.User.GetId()!);
            string[] names = fullNameUser.Split(' ');

            decimal totalPrice = await this.shopCartService.GetTotalPriceForItemsByUserIdAsync(this.User.GetId()!);


            //bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            //if (!isDealer)
            //{
            //    this.TempData[ErrorMessage] = "You must become an Dealer in order to add new cars!";

            //    return RedirectToAction("Become", "Dealer");
            //}

            try
            {
                PaymentProductFormModel viewModel = new PaymentProductFormModel()
                {
                    FirstName = names[0],
                    LastName = names[1],
                    TotalPrice = totalPrice
                };

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PaymentProduct(string submitButton, PaymentProductFormModel formModel)
        {
            if (submitButton == "Apply")
            {

                if (formModel.PromoCode == "1")
                {
                    decimal totalPrice = await this.shopCartService.GetTotalPriceForItemsByUserIdAsync(this.User.GetId()!);

                    decimal updatedPrice = await this.paymentService.PromoCode20UpdatePriceAsync(totalPrice);

                    formModel.TotalPrice = updatedPrice;
                    return this.View(formModel);
                }
            }
            else if (submitButton == "Buy")
            {
                string email = this.User.FindFirstValue(ClaimTypes.Email);

                return this.RedirectToAction("Index", "Home");

            }

            return this.RedirectToAction("All", "Product");



        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}