namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Product;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class ProductService : IProductService
    {
        private readonly MegaCarsDbContext dbContext;

        public ProductService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllProductViewModel>> AllProductsAsync()
        {
            IEnumerable<AllProductViewModel> products = await this.dbContext
                .Products
                .Select(p => new AllProductViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image
                })
                .ToArrayAsync();

            return products;
        }

        public async Task<bool> ExsistByIdAsync(string productId)
        {
            bool isFoundProduct = await this.dbContext
                .Products
                .AnyAsync(p => p.Id.ToString() == productId);

            return isFoundProduct;
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            Product product = await this.dbContext
                .Products
                .FirstAsync(p => p.Id.ToString() == productId);

            return product;
        }
    }
}