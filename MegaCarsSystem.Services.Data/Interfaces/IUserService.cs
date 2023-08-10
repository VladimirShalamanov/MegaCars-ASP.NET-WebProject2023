namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.User;
    public interface IUserService
    {
        // Views
        Task<IEnumerable<UserViewModel>> AllUsersAsync();

        // Func
        Task<string> GetFullNameByIdAsync(string userId);
    }
}