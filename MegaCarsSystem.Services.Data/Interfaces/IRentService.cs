namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Rent;

    public interface IRentService
    {
        Task<IEnumerable<RentViewModel>> AllRentsAsync();
    }
}