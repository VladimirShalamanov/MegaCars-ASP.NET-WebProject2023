namespace MegaCarsSystem.Services.Tests
{
    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;

    public static class DatabaseSeeder
    {
        public static ApplicationUser DealerUser;
        public static ApplicationUser RenterUser;
        public static Dealer Dealer;

        public static Car Car;

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

            Car = new Car()
            {
                Brand = "Reno",
                Model = "Scenic",
                YearOfManufacture = 2020,
                Horsepower = 111,
                EngineId = 1,
                GearboxId = 1,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description =
                    "The 2020 GT-R's standard twin-turbo 3.8-liter V-6 makes a mighty 565 horsepower. It hooks up to a six-speed automatic transmission and all-wheel drive that conspire to put all that power to the pavement. At our test track, the GT-R launched itself from zero to 60 mph in a mere 2.9 seconds.",
                ImageUrl = "https://cdn.motor1.com/images/mgl/1MlwW/s1/2020-nissan-gt-r-nismo-review.jpg",
                PricePerDay = 200.00M,
                CategoryId = 2,
                DealerId = Dealer.Id,
                RenterId = RenterUser.Id
            };
            dbContext.Cars.Add(Car);

            dbContext.SaveChanges();
        }
    }
}