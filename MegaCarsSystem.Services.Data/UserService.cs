namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly MegaCarsDbContext dbContext;

        public UserService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            bool isFoundUser = await this.dbContext
                .Users
                .AnyAsync(a => a.Id.ToString() == userId);

            return isFoundUser;
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            bool isFoundEmail = await this.dbContext
                .Users
                .AnyAsync(a => a.Email == email);

            return isFoundEmail;
        }
    }
}