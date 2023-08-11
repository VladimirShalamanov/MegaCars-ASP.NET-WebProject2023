namespace MegaCarsSystem.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Services.Data;
    using MegaCarsSystem.Services.Data.Interfaces;

    using static DatabaseSeeder;

    public class DealerServiceTests
    {
        private DbContextOptions<MegaCarsDbContext> dbOptions;
        private MegaCarsDbContext dbContext;
        
        private IDealerService dealerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<MegaCarsDbContext>()
                .UseInMemoryDatabase("MegaCarsInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new MegaCarsDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.dealerService = new DealerService(this.dbContext);
        }

        [Test]
        public async Task DealerExistsByUserId_ReturnTrueWhenExists()
        {
            string foundDealerUserId = DealerUser.Id.ToString();

            bool result = await this.dealerService.DealerExistsByUserIdAsync(foundDealerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByUserId_ReturnFalseWhenNotExists()
        {
            string wrongId = RenterUser.Id.ToString();

            bool result = await this.dealerService.DealerExistsByUserIdAsync(wrongId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DealerExistsByPhoneNumber_ReturnTrueWhenExists()
        {
            string foundDealerPhoneNumber = DatabaseSeeder.Dealer.PhoneNumber;

            bool result = await this.dealerService.DealerExistsByPhoneNumberAsync(foundDealerPhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DealerExistsByPhoneNumber_ReturnFalseWhenNotExists()
        {
            string wrongPhoneNumber = "+359000333";

            bool result = await this.dealerService.DealerExistsByPhoneNumberAsync(wrongPhoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasRentsCars_ReturnFalseIfNotHaveAny()
        {
            string userId = DatabaseSeeder.Dealer.Id.ToString();

            bool result = await this.dealerService.HasRentsByUserIdAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasRentsCars_ReturnTrueIfHaveAny()
        {
            string userId = RenterUser.Id.ToString();

            bool result = await this.dealerService.HasRentsByUserIdAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetDealerIdByUserId()
        {
            string userId = DealerUser.Id.ToString();

            string result = await this.dealerService.GetDealerIdByUserIdAsync(userId);

            Assert.AreEqual(result, DatabaseSeeder.Dealer.Id.ToString());
        }

        [Test]
        public async Task GetDealerIdByUserId_ReturnFalseNotFind()
        {
            string userId = RenterUser.Id.ToString();

            string result = await this.dealerService.GetDealerIdByUserIdAsync(userId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task HasCarWithIdAsync_ReturnNullWhenNotHave()
        {
            string userId = RenterUser.Id.ToString();
            string carId = Car.Id.ToString();

            bool result = await this.dealerService.HasCarWithIdAsync(userId, carId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasCarWithIdAsync_ReturnTrueWhenHaveAny()
        {
            string userId = DealerUser.Id.ToString();
            string carId = Car.Id.ToString();

            bool result = await this.dealerService.HasCarWithIdAsync(userId, carId);

            Assert.IsTrue(result);
        }
    }
}