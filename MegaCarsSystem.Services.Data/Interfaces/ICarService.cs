namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Web.ViewModels.Home;
    using MegaCarsSystem.Services.Data.Models.Car;
    using MegaCarsSystem.Services.Data.Models.Statistics;

    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> carsForIndexAsync();

        Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string agentId);

        Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel);

        Task<IEnumerable<string>> AllBrandNamesAsync();

        Task<IEnumerable<AllCarViewModel>> AllByAgentIdAsync(string agentId);

        Task<IEnumerable<AllCarViewModel>> AllByUserIdAsync(string userId);

        Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId);

        Task<CarFormModel> GetCarForEditByIdAsync(string carId);

        Task<bool> ExistByIdAsync(string carId);

        Task<bool> IsAgentWithIdOwnerOfCarWithIdAsync(string carId, string agentId);

        Task EditCarByIdAndFormModelAsync(string carId, CarFormModel formModel);

        Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId);

        Task DeleteCarByIdAync(string carId);

        Task<bool> IsRentedAsync(string carId);

        Task RentCarAsync(string carId, string userId);

        Task<bool> IsRentedByUserWithIdAsync(string carId, string userId);

        Task LeaveCarAsync(string carId);

        Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}