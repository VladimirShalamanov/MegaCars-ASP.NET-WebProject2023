namespace MegaCarsSystem.Services.Tests
{
    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;

    public static class DatabaseSeeder
    {
        public static ApplicationUser DealerUser;
        public static ApplicationUser RenterUser;
        public static Dealer Dealer;

        public static void SeedDatabase(MegaCarsDbContext dbContext)
        {
            DealerUser = new ApplicationUser()
            {
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                Email = "ivan@dealer.com",
                NormalizedEmail = "IVAN@DEALER.COM",
                EmailConfirmed = true,
                PasswordHash = "92c7d71b95dc6540fc58e891dbe649fe72ae5e93b5f42fd7fbdeefe6cef3e51d",
                ConcurrencyStamp = "0ddc3635-f062-48f2-b97a-d36e7060e7a3",
                SecurityStamp = "57946081-0051-4116-b68a-7dcc6dec4d6f",
                TwoFactorEnabled = false,
                FirstName = "Ivan",
                LastName = "Dealer"
            };
            RenterUser = new ApplicationUser()
            {
                UserName = "Petko",
                NormalizedUserName = "PETKO",
                Email = "petko@renter.com",
                NormalizedEmail = "PETKO@RENTER.COM",
                EmailConfirmed = true,
                PasswordHash = "92c7d71b95dc6540fc58e891dbe649fe72ae5e93b5f42fd7fbdeefe6cef3e51d",
                ConcurrencyStamp = "2666edd0-4ab1-46f1-ad29-48062549a12e",
                SecurityStamp = "7e190575-1c5d-4e8c-8d00-be0224402b62",
                FirstName = "Petko",
                LastName = "Renter"
            };
            Dealer = new Dealer()
            {
                PhoneNumber = "+359881112222",
                User = DealerUser
            };

            dbContext.Users.Add(DealerUser);
            dbContext.Users.Add(RenterUser);
            dbContext.Dealers.Add(Dealer);

            dbContext.SaveChanges();
        }
    }
}