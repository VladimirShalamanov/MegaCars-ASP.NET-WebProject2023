namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Dealer;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class DealerService : IDealerService
    {
        private readonly MegaCarsDbContext dbContext;

        public DealerService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> DealerExistsByUserIdAsync(string userId)
        {
            bool isFoundDealer = await this.dbContext
                .Dealers
                .AnyAsync(a => a.UserId.ToString() == userId);

            return isFoundDealer;
        }

        public async Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool isFoundDealer = await this.dbContext
                .Dealers
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return isFoundDealer;
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return user.RentedCars.Any();
        }

        public async Task Create(string userId, BecomeDealerFormModel model)
        {
            var newDealer = new Dealer()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Dealers.AddAsync(newDealer);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> GetDealerIdByUserIdAsync(string userId)
        {
            Dealer? dealer = await this.dbContext
                .Dealers
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (dealer == null)
            {
                return null;
            }

            return dealer.Id.ToString();
        }

        public async Task<bool> HasCarWithIdAsync(string? userId, string carId)
        {
            Dealer? dealer = await this.dbContext
                .Dealers
                .Include(a => a.OwnedCars)
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (dealer == null)
            {
                return false;
            }

            return dealer.OwnedCars.Any(c => c.Id.ToString() == carId.ToLower());
        }
    }
}