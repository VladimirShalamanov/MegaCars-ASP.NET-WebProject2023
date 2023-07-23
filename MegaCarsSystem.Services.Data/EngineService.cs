namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Web.ViewModels.Engine;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class EngineService : IEngineService
    {
        private readonly MegaCarsDbContext dbContext;

        public EngineService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllEngineNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Engines
                .Select(e => e.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool isFoundEngine = await this.dbContext
                .Engines
                .AnyAsync(e => e.Id == id);

            return isFoundEngine;
        }

        public async Task<IEnumerable<EngineForCarFormModel>> GetAllEnginesAsync()
        {
            var allEngines = await this.dbContext
                .Engines
                .AsNoTracking()
                .Select(e => new EngineForCarFormModel()
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToArrayAsync();

            return allEngines;
        }
    }
}