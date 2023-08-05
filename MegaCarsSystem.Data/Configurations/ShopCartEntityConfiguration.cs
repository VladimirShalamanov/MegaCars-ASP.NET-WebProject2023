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
                .WithOne(s => s.ShoppingCart)
                .HasForeignKey<ApplicationUser>(a => a.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(GenerateShoppingCarts());
        }

        // Generate shopping carts for User,Dealer and Admin
        //private ShoppingCart[] GenerateShoppingCarts()
        //{
        //    ICollection<ShoppingCart> shoppingCarts = new HashSet<ShoppingCart>();

        //    // Add for 1st User

        //    ShoppingCart dealerShopCart = new ShoppingCart()
        //    {
        //        Id = Guid.Parse(DealerShoppingCartId),
        //        UserId = Guid.Parse(UserDealerId)
        //    };
        //    shoppingCarts.Add(dealerShopCart);

        //    ShoppingCart adminShopCart = new ShoppingCart()
        //    {
        //        Id = Guid.Parse(AdminShoppingCartId_Development),
        //        UserId = Guid.Parse(UserDealerId_Development)
        //    };
        //    shoppingCarts.Add(adminShopCart);

        //    return shoppingCarts.ToArray();
        //}
    }
}