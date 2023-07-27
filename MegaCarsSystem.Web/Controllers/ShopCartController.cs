namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Web.ViewModels.ShopCart;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;

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
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(string id)
        {
            if (this.User.Identity?.IsAuthenticated == false)
            {
                this.TempData[ErrorMessage] = "You must be login user if you want to buying products!";

                return this.RedirectToAction("Login", "User");
            }

            bool productExists = await this.productService.ExistsProductByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided id does not exist!";

                return this.RedirectToAction("All", "Product");
            }

            string userId = this.User.GetId()!;

            try
            {
                await this.shopCartService.AddToCartByIdAsync(userId, id);

                this.TempData[SuccessMessage] = "You have successfully added the product to your shopping cart.";

                return null;
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            bool itemExists = await this.shopCartService.ExistsItemByIdAsync(id);

            if (!itemExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided id does not exist in your shopping cart!";

                return this.RedirectToAction("All", "ShopCart");
            }

            string userId = this.User.GetId()!;

            try
            {
                await this.shopCartService.RemoveFromCartByIdAsync(userId, id);

                this.TempData[WarningMessage] = "You have successfully removed the product from your shopping cart.";
                       
                return this.RedirectToAction("All", "ShopCart");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            string userId = this.User.GetId()!;

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