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
        }
    }
}