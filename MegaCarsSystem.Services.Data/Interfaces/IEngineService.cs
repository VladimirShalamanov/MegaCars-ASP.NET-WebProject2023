namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Engine;

    public interface IEngineService
    {
        Task<IEnumerable<EngineForCarFormModel>> GetAllEnginesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllEngineNamesAsync();
    }
}