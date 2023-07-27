namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Engine;

    public interface IEngineService
    {
        Task<IEnumerable<EngineForCarFormModel>> GetAllEnginesAsync();

        Task<bool> ExistsEngineByIdAsync(int id);

        Task<IEnumerable<string>> AllEngineNamesAsync();
    }
}