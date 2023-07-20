namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;
    using MegaCarsSystem.Web.ViewModels.ShopCart;

    [Authorize]
    public class ShopCartController : Controller
    {
        private readonly IShopCartService shopCartService;
        private readonly IProductService productService;

        public ShopCartController(
            IShopCartService shopCartService,
            IProductService productService)
        {
            this.shopCartService = shopCartService;
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string id)
        {
            bool productExists = await this.productService.ExsistByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided id does not exist!";

                return this.RedirectToAction("All", "Product");
            }

            if (!this.User.Identity?.IsAuthenticated ?? false)
            {
                this.TempData[ErrorMessage] = "You must be login user if you want to buying products!";

                return this.Redirect("/Identity/Account/Login");
            }

            string userId = this.User.GetId()!;

            bool shopCartExists = await this.shopCartService.ExsistByIdAsync(userId);

            if (!shopCartExists)
            {
                await this.shopCartService.CreateShopCartByIdAsync(userId);
            }

            try
            {
                await this.shopCartService.AddToCartByIdAsync(userId, id);

                return this.RedirectToAction("All", "Product");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            if (!this.User.Identity?.IsAuthenticated ?? false)
            {
                this.TempData[ErrorMessage] = "You must be login user if you want to buying products!";

                return this.Redirect("/Identity/Account/Login");
            }

            string userId = this.User.GetId()!;

            bool shopCartExists = await this.shopCartService.ExsistByIdAsync(userId);

            if (!shopCartExists)
            {
                await this.shopCartService.CreateShopCartByIdAsync(userId);
            }

            try
            {
               IEnumerable<ItemsForShopCartViewModel> viewModel = await this.shopCartService.AllItemsForShopCartByIdAsync(userId);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}