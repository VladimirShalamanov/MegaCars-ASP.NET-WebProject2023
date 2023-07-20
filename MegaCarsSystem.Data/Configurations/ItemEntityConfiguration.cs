namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
   
    using MegaCarsSystem.Data.Models;

    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasOne(i => i.ShopCart)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.ShopCartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}