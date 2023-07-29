namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Gearbox;
    
    public interface IGearboxService
    {
        // Views
        Task<IEnumerable<GearboxForCarFormModel>> GetAllGearboxesAsync();

        // Func
        Task<IEnumerable<string>> AllGearboxNamesAsync();

        // Check
        Task<bool> ExistsGearboxByIdAsync(int id);
    }
}