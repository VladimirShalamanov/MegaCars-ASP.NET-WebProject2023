namespace MegaCarsSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<bool> UserExistsByIdAsync(string userId);
    }
}