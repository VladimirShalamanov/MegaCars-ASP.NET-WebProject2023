namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.ShopCart;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class ShopCartService : IShopCartService
    {
        private readonly MegaCarsDbContext dbContext;

        public ShopCartService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToCartByIdAsync(string userId, string productId)
        {
            ShopCart shopCart = await this.dbContext
                 .ShopCarts
                 .FirstAsync(u => u.UserId.ToString() == userId);

            Product product = await this.dbContext
                .Products
                .FirstAsync(p => p.Id.ToString() == productId.ToLower());

            Item item = new Item()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = 1,
                Price = product.Price,
                Image = product.Image,
                ShopCartId = shopCart.Id
            };

            await this.dbContext.Items.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemsForShopCartViewModel>> AllItemsForShopCartByIdAsync(string userId)
        {
            ShopCart shopCart = await this.dbContext
                 .ShopCarts
                 .FirstAsync(u => u.UserId.ToString() == userId);

            IEnumerable<ItemsForShopCartViewModel> allItems = await this.dbContext
                .Items
                .Where(i => i.ShopCartId == shopCart.Id)
                .Select(i => new ItemsForShopCartViewModel
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Image = i.Image,
                })
                .ToArrayAsync();

            return allItems;
        }

        public async Task<bool> ExsistByIdAsync(string userId)
        {
            bool isFoundShopCart = await this.dbContext
                .ShopCarts
                .AnyAsync(p => p.UserId.ToString() == userId);

            return isFoundShopCart;
        }

        public async Task CreateShopCartByIdAsync(string userId)
        {
            ApplicationUser user = await this.dbContext
                 .Users
                 .FirstAsync(u => u.Id.ToString() == userId);

            var newShopCart = new ShopCart()
            {
                UserId = Guid.Parse(userId)
            };

            user.ShopCart = newShopCart;
            await this.dbContext.ShopCarts.AddAsync(newShopCart);
            await this.dbContext.SaveChangesAsync();
        }
    }
}