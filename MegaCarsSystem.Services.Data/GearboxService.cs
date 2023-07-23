namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Web.ViewModels.Gearbox;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class GearboxService : IGearboxService
    {
        private readonly MegaCarsDbContext dbContext;

        public GearboxService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllGearboxNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Gearboxes
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool isFoundGearbox = await this.dbContext
                .Gearboxes
                .AnyAsync(c => c.Id == id);

            return isFoundGearbox;
        }

        public async Task<IEnumerable<GearboxForCarFormModel>> GetAllGearboxesAsync()
        {
            var allGearboxes = await this.dbContext
                .Gearboxes
                .AsNoTracking()
                .Select(c => new GearboxForCarFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allGearboxes;
        }
    }
}