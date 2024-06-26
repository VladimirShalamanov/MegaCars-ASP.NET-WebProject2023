﻿namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AppUserSeedEC : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
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
                NormalizedUserName = UserEmail,
                FirstName = UserFirstName,
                LastName = UserLastName,
                ShoppingCartId = Guid.Parse(UserShoppingCartId)
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
                NormalizedUserName = DealerEmail,
                FirstName = DealerFirstName,
                LastName = DealerLastName,
                ShoppingCartId = Guid.Parse(DealerShoppingCartId)
            };
            dealerUser.PasswordHash = hasher.HashPassword(dealerUser, DealerPassword);
            dealerUser.SecurityStamp = Guid.NewGuid().ToString();
            usersUDA.Add(dealerUser);

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse(UserDealerId_Development),
                Email = AdminEmail_Development,
                NormalizedEmail = AdminEmail_Development,
                UserName = AdminEmail_Development,
                NormalizedUserName = AdminEmail_Development,
                FirstName = AdminFirstName_Development,
                LastName = AdminLastName_Development,
                ShoppingCartId = Guid.Parse(AdminShoppingCartId_Development)
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, AdminPassword_Development);
            adminUser.SecurityStamp = Guid.NewGuid().ToString();
            usersUDA.Add(adminUser);

            return usersUDA.ToArray();
        }

    }
}