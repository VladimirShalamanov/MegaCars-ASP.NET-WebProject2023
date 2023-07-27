namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Gearbox;
    
    public interface IGearboxService
    {
        Task<IEnumerable<GearboxForCarFormModel>> GetAllGearboxesAsync();

        Task<bool> ExistsGearboxByIdAsync(int id);

        Task<IEnumerable<string>> AllGearboxNamesAsync();
    }
}