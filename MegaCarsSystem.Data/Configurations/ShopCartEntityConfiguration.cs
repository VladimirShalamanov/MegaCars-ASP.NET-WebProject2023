namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class ShopCartEntityConfiguration : IEntityTypeConfiguration<ShopCart>
    {
        public void Configure(EntityTypeBuilder<ShopCart> builder)
        {
            builder
                .HasOne(s => s.User)
                .WithOne(s => s.ShopCart)
                .HasForeignKey<ShopCart>(s => s.UserId)
                .IsRequired();

            builder.HasData(GenerateShoppingCarts());
        }

        // Generate shopping carts for User,Dealer and Admin
        private ShopCart[] GenerateShoppingCarts()
        {
            ICollection<ShopCart> shoppingCarts = new HashSet<ShopCart>();

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