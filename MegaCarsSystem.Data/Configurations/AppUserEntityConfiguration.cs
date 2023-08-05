namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AppUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("TestF");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("TestL");

            builder
                .HasOne(u => u.ShoppingCart)
                .WithOne(u => u.User)
                .HasForeignKey<ShopCart>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}