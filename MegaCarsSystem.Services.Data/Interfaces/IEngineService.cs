namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Engine;

    public interface IEngineService
    {
        // Views
        Task<IEnumerable<EngineForCarFormModel>> GetAllEnginesAsync();

        // Func
        Task<IEnumerable<string>> AllEngineNamesAsync();

        // Check
        Task<bool> ExistsEngineByIdAsync(int id);
    }
}