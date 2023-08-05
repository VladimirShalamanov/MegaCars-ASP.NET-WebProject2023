namespace MegaCarsSystem.Data.Configurations
{
    using MegaCarsSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Common.GeneralApplicationConstants;

    public class ShopCartSeedEC : IEntityTypeConfiguration<ShopCart>
    {
        public void Configure(EntityTypeBuilder<ShopCart> builder)
        {
            builder.HasData(GenerateShoppingCarts());
        }

        // Generate shopping carts for User,Dealer and Admin
        private ShopCart[] GenerateShoppingCarts()
        {
            ICollection<ShopCart> shoppingCarts = new HashSet<ShopCart>();

            ShopCart userShopCart = new ShopCart()
            {
                Id = Guid.Parse(UserShoppingCartId),
                UserId = Guid.Parse(UserId)
            };
            shoppingCarts.Add(userShopCart);

            ShopCart dealerShopCart = new ShopCart()
            {
                Id = Guid.Parse(DealerShoppingCartId),
                UserId = Guid.Parse(UserDealerId)
            };
            shoppingCarts.Add(dealerShopCart);

            ShopCart adminShopCart = new ShopCart()
            {
                Id = Guid.Parse(AdminShoppingCartId_Development),
                UserId = Guid.Parse(UserDealerId_Development)
            };
            shoppingCarts.Add(adminShopCart);

            return shoppingCarts.ToArray();
        }
    }
}