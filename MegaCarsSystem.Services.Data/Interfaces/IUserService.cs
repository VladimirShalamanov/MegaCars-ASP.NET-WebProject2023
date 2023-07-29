namespace MegaCarsSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        // Func
        Task<string> GetFullNameByEmailAsync(string email);

        // Check
        Task<bool> UserExistsByIdAsync(string userId);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}