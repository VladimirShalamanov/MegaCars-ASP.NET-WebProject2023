namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.User;
    public interface IUserService
    {
        // Views
        Task<IEnumerable<UserViewModel>> AllUsersAsync();

        // Func
        Task<string> GetFullNameByEmailAsync(string email);
        Task<string> GetFullNameByIdAsync(string userId);

        // Check
        Task<bool> UserExistsByIdAsync(string userId);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}