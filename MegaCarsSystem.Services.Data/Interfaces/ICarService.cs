namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Web.ViewModels.Home;
    using MegaCarsSystem.Services.Data.Models.Car;
    using MegaCarsSystem.Services.Data.Models.Statistics;

    public interface ICarService
    {
        // Views
        Task<IEnumerable<IndexViewModel>> carsForIndexAsync();
        Task<AllCarsFilteredAndPagedServiceModel> AllCarsAsync(AllCarsQueryModel queryModel);

        Task<IEnumerable<AllCarViewModel>> AllByUserIdAsync(string userId);
        Task<IEnumerable<AllCarViewModel>> AllByDealerIdAsync(string dealerId);
        Task<IEnumerable<string>> AllBrandNamesAsync();

        // Create
        Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string dealerId);

        // Check
        Task<bool> ExistCarByIdAsync(string carId);
        Task<bool> IsDealerWithIdOwnerOfCarWithIdAsync(string carId, string dealerId);

        // Details
        Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId);

        // Edit
        Task<CarFormModel> GetCarForEditByIdAsync(string carId);
        Task EditCarByIdAndFormModelAsync(string carId, CarFormModel formModel);

        // Del
        Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId);
        Task DeleteCarByIdAync(string carId);


        // Rent func
        Task<bool> IsRentedAsync(string carId);
        Task<bool> IsRentedByUserWithIdAsync(string carId, string userId);

        Task RentCarAsync(string carId, string userId);
        Task LeaveCarAsync(string carId);

        // WebApi
        Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}