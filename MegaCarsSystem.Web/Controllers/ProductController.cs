﻿namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MegaCarsSystem.Web.ViewModels.Product;
    using MegaCarsSystem.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllProductViewModel> viewModel = await this.productService.AllProductsAsync();

            return this.View(viewModel);
        }
    }
}