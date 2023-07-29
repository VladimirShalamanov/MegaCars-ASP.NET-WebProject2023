namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Dealer;

    public interface IDealerService
    {
        // Create
        Task Create(string userId, BecomeDealerFormModel model);

        // Func
        Task<string> GetDealerIdByUserIdAsync(string userId);

        // Check
        Task<bool> HasRentsByUserIdAsync(string userId);
        Task<bool> DealerExistsByUserIdAsync(string userId);
        Task<bool> DealerExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> HasCarWithIdAsync(string? userId, string carId);
    }
}