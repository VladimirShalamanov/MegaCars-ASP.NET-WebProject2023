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
                .HasOne(u => u.ShopCart)
                .WithOne(u => u.User)
                .HasForeignKey<ApplicationUser>(s => s.Id)
                .IsRequired();

            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> usersUDA = new List<ApplicationUser>();

            ApplicationUser userGuest = new ApplicationUser()
            {
                Id = Guid.Parse(UserId),
                Email = UserEmail,
                NormalizedEmail = UserEmail,
                UserName = UserEmail,
                NormalizedUserName = UserEmail,                FirstName = UserFirstName,
                LastName = UserLastName
            };
            userGuest.PasswordHash = hasher.HashPassword(userGuest, UserPassword);
            userGuest.SecurityStamp = Guid.NewGuid().ToString();
            usersUDA.Add(userGuest);

            ApplicationUser dealerUser = new ApplicationUser()
            {
                Id = Guid.Parse(UserDealerId),
                Email = DealerEmail,
                NormalizedEmail = DealerEmail,
                UserName = DealerEmail,
                NormalizedUserName = DealerEmail,                FirstName = DealerFirstName,
                LastName = DealerLastName
            };
            dealerUser.PasswordHash = hasher.HashPassword(dealerUser, DealerPassword);
            dealerUser.SecurityStamp = Guid.NewGuid().ToString();
            usersUDA.Add(dealerUser);

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse(Development_UserDealerId),
                Email = Development_AdminEmail,
                NormalizedEmail = Development_AdminEmail,
                UserName = Development_AdminEmail,
                NormalizedUserName = Development_AdminEmail,                FirstName = Development_AdminFirstName,
                LastName = Development_AdminLastName
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, Development_AdminPassword);
            adminUser.SecurityStamp = Guid.NewGuid().ToString();
            usersUDA.Add(adminUser);

            return usersUDA.ToArray();
        }
    }
}