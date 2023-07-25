namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    
    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AppUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        //private readonly MegaCarsDbContext dbContext;

        //public AppUserEntityConfiguration(MegaCarsDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

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

            //if (!await this.dbContext.Users.AnyAsync(u => u.Email == GuestEmail))
            //{
            //}
            builder.HasData(GenerateGuestUser());
        }

        private ApplicationUser GenerateGuestUser()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser guestUser = new ApplicationUser()
            {
                Id = Guid.Parse("c8456483-8aa7-4064-912d-967070b2b115"),
                Email = GuestEmail,
                NormalizedEmail = GuestEmail,
                UserName = GuestEmail,
                NormalizedUserName = GuestEmail,                FirstName = GuestFirstName,
                LastName = GuestLastName
            };

            //await this.userManager.SetEmailAsync(guestUer, GuestEmail);
            //await this.userManager.SetUserNameAsync(guestUer, GuestEmail);

            //await this.userManager.CreateAsync(guestUer, GuestPassword);

            guestUser.PasswordHash = hasher.HashPassword(guestUser, GuestPassword);

            return guestUser;
        }
    }
}