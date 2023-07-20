namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Agent;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class AgentService : IAgentService
    {
        private readonly MegaCarsDbContext dbContext;

        public AgentService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistsByUserIdAsync(string userId)
        {
            bool isFoundAgent = await this.dbContext
                .Agents
                .AnyAsync(a => a.UserId.ToString() == userId);

            return isFoundAgent;
        }

        public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool isFoundAgent = await this.dbContext
                .Agents
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return isFoundAgent;
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

        public async Task Create(string userId, BecomeAgentFormModel model)
        {
            var newAgent = new Agent()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Agents.AddAsync(newAgent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> GetAgentIdByUserIdAsync(string userId)
        {
            Agent? agent = await this.dbContext
                .Agents
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (agent == null)
            {
                return null;
            }

            return agent.Id.ToString();
        }

        public async Task<bool> HasCarWithIdAsync(string? userId, string carId)
        {
            Agent? agent = await this.dbContext
                .Agents
                .Include(a => a.OwnedCars)
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (agent == null)
            {
                return false;
            }

            return agent.OwnedCars.Any(c => c.Id.ToString() == carId.ToLower());
        }
    }
}