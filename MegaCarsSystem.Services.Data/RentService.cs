namespace MegaCarsSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using MegaCarsSystem.Data;
    using MegaCarsSystem.Web.ViewModels.Rent;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class RentService : IRentService
    {
        private readonly MegaCarsDbContext dbContext;

        public RentService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RentViewModel>> AllRentsAsync()
        {
            IEnumerable<RentViewModel> allRents = await this.dbContext
                .Cars
                .Include(r => r.Renter)
                .Include(d => d.Dealer)
                .ThenInclude(u => u.User)
                .Where(r => r.RenterId.HasValue)
                .Select(c => new RentViewModel()
                {
                    Title = $"{c.Brand} {c.Model}",
                    ImageUrl = c.ImageUrl,
                    DealerFullName =
                        $"{c.Dealer.User.FirstName} {c.Dealer.User.LastName}",
                    DealerEmail = c.Dealer.User.Email,
                    RenterFullName =
                        $"{c.Renter!.FirstName} {c.Renter.LastName}",
                    RenterEmail = c.Renter.Email
                })
                .ToArrayAsync();

            return allRents;
        }
    }
}