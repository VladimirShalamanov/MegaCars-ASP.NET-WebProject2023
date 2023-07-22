namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

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
                .HasOne(e => e.ShopCart)
                .WithOne(e => e.User) 
                .IsRequired();
        }
    }
}