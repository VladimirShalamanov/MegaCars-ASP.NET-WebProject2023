namespace MegaCarsSystem.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;

    using static DatabaseSeeder;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Services.Data;

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
            string foundDealerUserId = RenterUser.Id.ToString();

            bool result = await this.dealerService.DealerExistsByUserIdAsync(foundDealerUserId);

            Assert.IsFalse(result);
        }
    }
}