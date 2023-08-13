namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.User;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly MegaCarsDbContext dbContext;

        public UserService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                Dealer? dealer = this.dbContext
                    .Dealers
                    .FirstOrDefault(d => d.UserId.ToString() == user.Id);

                if (dealer != null)
                {
                    user.PhoneNumber = dealer.PhoneNumber;
                }
                else
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            return allUsers;
        }
    }
}