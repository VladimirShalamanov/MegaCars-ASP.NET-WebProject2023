namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    public class ShopCartEntityConfiguration : IEntityTypeConfiguration<ShopCart>
    {
        public void Configure(EntityTypeBuilder<ShopCart> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithOne(e => e.ShopCart)
                .HasForeignKey<ShopCart>(e => e.UserId)
                .IsRequired();
        }
    }
}