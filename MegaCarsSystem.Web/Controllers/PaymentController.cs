namespace MegaCarsSystem.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using ViewModels.Payment;
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
            string[] namesOfUser = (await this.userService.GetFullNameByIdAsync(this.User.GetId()!)).Split(' ');

            decimal totalPrice = await this.shopCartService.GetTotalPriceForItemsByUserIdAsync(this.User.GetId()!);

            try
            {
                PaymentProductFormModel viewModel = new PaymentProductFormModel()
                {
                    FirstName = namesOfUser[0],
                    LastName = namesOfUser[1],
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

            string namesOfUser = await this.userService.GetFullNameByIdAsync(this.User.GetId()!);
            string[] fAndLaName = (await this.userService.GetFullNameByIdAsync(this.User.GetId()!)).Split(' ');

            decimal totalPrice = await this.shopCartService.GetTotalPriceForItemsByUserIdAsync(this.User.GetId()!);

            if (submitButton == "Apply")
            {
                try
                {
                    if (formModel.PromoCode == PromoCodes)
                    {
                        decimal updatedPrice = await this.paymentService.PromoCode20UpdatePrice(totalPrice);

                        decimal discount = await this.paymentService.TransformDiscountPriceByTwoSums(totalPrice, updatedPrice);

                        formModel.TotalPrice = updatedPrice;
                        formModel.Discount = discount;
                    }
                    else
                    {
                        formModel.TotalPrice = totalPrice;

                        this.ModelState.AddModelError(nameof(formModel.PromoCode), "The Promo Code entered is incorrect or does not exist!");

                    }

                    ModelState["CheckEmail"]!.Errors.Clear();
                    ModelState["City"]!.Errors.Clear();
                    ModelState["Address"]!.Errors.Clear();
                    ModelState["PhoneNumber"]!.Errors.Clear();

                    formModel.FirstName = fAndLaName[0];
                    formModel.LastName = fAndLaName[1];
                    return this.View(formModel);
                }
                catch (Exception)
                {
                    return this.GeneralError();
                }
            }

            // submitButton == "Buy"

            string email = this.User.FindFirstValue(ClaimTypes.Email);

            if (!ModelState.IsValid || formModel.CheckEmail != email)
            {
                if (formModel.CheckEmail != email)
                {
                    this.ModelState.AddModelError(nameof(formModel.CheckEmail), "The Email entered is incorrect or does not exist!");
                }

                if (formModel.PromoCode == PromoCodes)
                {
                    decimal updatedPrice = await this.paymentService.PromoCode20UpdatePrice(totalPrice);

                    decimal discount = await this.paymentService.TransformDiscountPriceByTwoSums(totalPrice, updatedPrice);

                    formModel.TotalPrice = updatedPrice;
                    formModel.Discount = discount;
                }
                else
                {
                    formModel.TotalPrice = totalPrice;
                }

                formModel.FirstName = fAndLaName[0];
                formModel.LastName = fAndLaName[1];
                return this.View(formModel);
            }

            try
            {
                // Create Order
                string orderPrice = string.Empty;
                if (formModel.PromoCode == PromoCodes)
                {
                    decimal updatedPrice = await this.paymentService.PromoCode20UpdatePrice(totalPrice);

                    orderPrice = $"{updatedPrice:f2}";
                }
                else
                {
                    orderPrice = $"{totalPrice:f2}";
                }

                await this.paymentService.CreateOrderByIdAsync(formModel, this.User.GetId()!, namesOfUser, orderPrice);

                // In New Order Controller I need to add the selected items in the story order for more details => I don't have time

                await this.shopCartService.ClearShopCartAfterCreatedOrderByIdAsync(this.User.GetId()!);
            }
            catch (Exception)
            {
                if (formModel.PromoCode == PromoCodes)
                {
                    decimal updatedPrice = await this.paymentService.PromoCode20UpdatePrice(totalPrice);

                    decimal discount =
                        await this.paymentService.TransformDiscountPriceByTwoSums(totalPrice, updatedPrice);

                    formModel.TotalPrice = updatedPrice;
                    formModel.Discount = discount;
                }
                else
                {
                    formModel.TotalPrice = totalPrice;
                }

                formModel.FirstName = fAndLaName[0];
                formModel.LastName = fAndLaName[1];
                return this.View(formModel);
            }

            this.TempData[SuccessMessage] = "The Order was created successfully!";

            return this.RedirectToAction("Index", "Home");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}