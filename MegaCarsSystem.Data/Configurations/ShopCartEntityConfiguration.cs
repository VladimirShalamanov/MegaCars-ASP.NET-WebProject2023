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

            builder.HasData(GenerateShoppingCartsForAgentAndAdmin());
        }

        private ShopCart[] GenerateShoppingCartsForAgentAndAdmin()
        {
            ICollection<ShopCart> shoppingCarts = new HashSet<ShopCart>();

            ShopCart agentShopCart = new ShopCart()
            {
                Id = Guid.Parse(AgentShoppingCartId),
                UserId = Guid.Parse(UserAgentId)
            };
            shoppingCarts.Add(agentShopCart);

            ShopCart adminShopCart = new ShopCart()
            {
                Id = Guid.Parse(Development_AdminShoppingCartId),
                UserId = Guid.Parse(Development_UserAdminId)
            };
            shoppingCarts.Add(adminShopCart);

            return shoppingCarts.ToArray();
        }
    }
}