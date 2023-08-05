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
            string foundDealerPhoneNumber = Dealer.PhoneNumber;

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
    }
}