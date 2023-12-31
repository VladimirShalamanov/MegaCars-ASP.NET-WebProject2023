﻿using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.ShopCart;
    using MegaCarsSystem.Services.Data.Interfaces;

    using static Common.GeneralApplicationConstants;

    public class ShopCartService : IShopCartService
    {
        private readonly MegaCarsDbContext dbContext;

        public ShopCartService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task<int> GetAllItemsQuantityByUserIdAsync(string userId)
        {
            ShopCart shopCart = await this.dbContext
                .ShopCarts
                .Include(s => s.Items)
                .FirstAsync(u => u.UserId.ToString() == userId);

            if (!shopCart.Items.Any())
            {
                return 0;
            }

            int totalItems = shopCart.Items.Sum(i => i.Quantity);

            return totalItems;
        }

        public async Task<decimal> GetTotalPriceForItemsByUserIdAsync(string userId)
        {
            ShopCart shopCart = await this.dbContext
                .ShopCarts
                .Include(s => s.Items)
                .FirstAsync(u => u.UserId.ToString() == userId);

            decimal totalPrice = shopCart.Items.Sum(i => i.Quantity * i.Price);

            if (totalPrice < MinSumForFreeOrder)
            {
                totalPrice += Delivery;
            }

            return totalPrice;
        }
        public async Task AddToCartByIdAsync(string userId, string productId)
        {
            ShopCart shopCart = await this.dbContext
                 .ShopCarts
                 .FirstAsync(u => u.UserId.ToString() == userId);

            Product product = await this.dbContext
                .Products
                .FirstAsync(p => p.Id.ToString() == productId.ToLower());

            Item foundItem = await this.dbContext.Items
                .FirstOrDefaultAsync(i => i.ShopCartId == shopCart.Id
                                           && i.Name == product.Name);

            if (foundItem != null)
            {
                foundItem.Quantity++;
            }
            else
            {
                Item item = new Item()
                {
                    Name = product.Name,
                    Quantity = 1,
                    Price = product.Price,
                    Image = product.Image,
                    ShopCartId = shopCart.Id
                };

                await this.dbContext.Items.AddAsync(item);
                shopCart.Items.Add(item);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromCartByIdAsync(string userId, string itemId)
        {
            Item itemToRemove = await this.dbContext
                .Items
                .FirstAsync(p => p.Id.ToString() == itemId.ToLower());

            this.dbContext.Items.Remove(itemToRemove);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task IncreaseQuantityWithOneByIdAsync(string userId, string itemId)
        {
            Item item = await this.dbContext
                .Items
                .FirstAsync(p => p.Id.ToString() == itemId.ToLower());

            item.Quantity++;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DecreaseQuantityWithOneByIdAsync(string userId, string itemId)
        {
            Item item = await this.dbContext
                .Items
                .FirstAsync(p => p.Id.ToString() == itemId.ToLower());

            item.Quantity--;

            if (item.Quantity == 0)
            {
                this.dbContext.Items.Remove(item);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task ClearShopCartAfterCreatedOrderByIdAsync(string userId)
        {
            ShopCart shopCart = await this.dbContext
                .ShopCarts
                .FirstAsync(u => u.UserId.ToString() == userId);

            Item[] items = await this.dbContext
                .Items
                .Where(p => p.ShopCartId.ToString() == shopCart.Id.ToString().ToLower())
                .ToArrayAsync();

            this.dbContext.Items.RemoveRange(items);
            shopCart.Items.Clear();
            await this.dbContext.SaveChangesAsync();
        }


        public async Task<bool> ExistsItemByIdAsync(string itemId)
        {
            bool isFoundItem = await this.dbContext
                .Items
                .AnyAsync(p => p.Id.ToString() == itemId);

            return isFoundItem;
        }

        public async Task<bool> ExistsShopCartByIdAsync(string userId)
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

            await this.dbContext.ShopCarts.AddAsync(newShopCart);
            user.ShoppingCartId = newShopCart.Id;
            await this.dbContext.SaveChangesAsync();
        }
    }
}