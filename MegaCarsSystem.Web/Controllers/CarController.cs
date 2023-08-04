namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Services.Data.Models.Car;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationsMessagesConstants;
    using Microsoft.Extensions.Caching.Memory;

    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IEngineService engineService;
        private readonly IGearboxService gearboxService;
        private readonly ICategoryService categoryService;

        private readonly IDealerService dealerService;

        private readonly IMemoryCache memoryCache;

        public CarController(
            ICarService carService,
            IEngineService engineService,
            IGearboxService gearboxService,
            ICategoryService categoryService,
            IDealerService dealerService,
            IMemoryCache memoryCache)
        {
            this.carService = carService;
            this.engineService = engineService;
            this.gearboxService = gearboxService;
            this.categoryService = categoryService;

            this.dealerService = dealerService;

            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel queryModel)
        {
            AllCarsFilteredAndPagedServiceModel serviceModel =
                await this.carService.AllCarsAsync(queryModel);

            queryModel.Cars = serviceModel.Cars;
            queryModel.TotalCars = serviceModel.TotalCarsCount;

            queryModel.Brands = await this.carService.AllBrandNamesAsync();
            queryModel.Engines = await this.engineService.AllEngineNamesAsync();
            queryModel.Gearboxes = await this.gearboxService.AllGearboxNamesAsync();
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isDealer)
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to add new cars!";

                return RedirectToAction("Become", "Dealer");
            }

            try
            {
                CarFormModel carModel = new CarFormModel()
                {
                    Engines = await this.engineService.GetAllEnginesAsync(),
                    Gearboxes = await this.gearboxService.GetAllGearboxesAsync(),
                    Categories = await this.categoryService.GetAllCategoriesAsync()
                };

                return View(carModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel formModel)
        {
            bool isDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isDealer)
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to add new cars!";

                return RedirectToAction("Become", "Dealer");
            }

            bool engineExists = await this.engineService.ExistsEngineByIdAsync(formModel.EngineId);

            if (!engineExists)
            {
                this.ModelState.AddModelError(nameof(formModel.EngineId), "Selected engine with type fuel does not exist!");
            }

            bool gearboxExists = await this.gearboxService.ExistsGearboxByIdAsync(formModel.GearboxId);

            if (!gearboxExists)
            {
                this.ModelState.AddModelError(nameof(formModel.GearboxId), "Selected gearbox does not exist!");
            }

            bool categoryExists = await this.categoryService.ExistsCategoryByIdAsync(formModel.CategoryId);

            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(formModel.CategoryId), "Selected category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return this.View(formModel);
            }

            try
            {
                string? dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

                string carId = await this.carService.CreateAndReturnIdAsync(formModel, dealerId!);

                this.TempData[SuccessMessage] = "Car was added successfully!";

                return this.RedirectToAction("Details", "Car", new { id = carId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new car! Please try again later or contact administrator!");

                formModel.Engines = await this.engineService.GetAllEnginesAsync();
                formModel.Gearboxes = await this.gearboxService.GetAllGearboxesAsync();
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return this.View(formModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Mine", "Car", new { Area = AdminAreaName });
            }
            List<AllCarViewModel> myCars = new List<AllCarViewModel>();

            string userId = this.User.GetId()!;
            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(userId);

            try
            {
                if (this.User.IsAdmin())
                {
                    string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(userId);

                    myCars.AddRange(await this.carService.AllByDealerIdAsync(dealerId));
                    myCars.AddRange(await this.carService.AllByUserIdAsync(userId));

                    myCars = myCars.DistinctBy(c => c.Id).ToList();
                }
                else if (isUserDealer)
                {
                    string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(userId);

                    myCars.AddRange(await this.carService.AllByDealerIdAsync(dealerId));
                }
                else
                {
                    myCars.AddRange(await this.carService.AllByUserIdAsync(userId));
                }

                return this.View(myCars);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            try
            {
                CarDetailsViewModel viewModel = await this.carService.GetDetailsByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserDealer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to edit car info!";

                return this.RedirectToAction("Become", "Dealer");
            }

            string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

            bool isDealerOwner = await this.carService.IsDealerWithIdOwnerOfCarWithIdAsync(id, dealerId);

            if (!isDealerOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Dealer owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                CarFormModel formModel = await this.carService.GetCarForEditByIdAsync(id);

                formModel.Engines = await this.engineService.GetAllEnginesAsync();
                formModel.Gearboxes = await this.gearboxService.GetAllGearboxesAsync();
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                formModel.Engines = await this.engineService.GetAllEnginesAsync();
                formModel.Gearboxes = await this.gearboxService.GetAllGearboxesAsync();
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return this.View(formModel);
            }

            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserDealer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to edit car info!";

                return this.RedirectToAction("Become", "Dealer");
            }

            string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

            bool isDealerOwner = await this.carService.IsDealerWithIdOwnerOfCarWithIdAsync(id, dealerId);

            if (!isDealerOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Dealer owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                await this.carService.EditCarByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update the car. Please try again later or tontact administrator!");

                formModel.Engines = await this.engineService.GetAllEnginesAsync();
                formModel.Gearboxes = await this.gearboxService.GetAllGearboxesAsync();
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

                return this.View(formModel);
            }

            this.TempData[SuccessMessage] = "Car was edited successfully!";

            return this.RedirectToAction("Details", "Car", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserDealer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to edit car info!";

                return this.RedirectToAction("Become", "Dealer");
            }

            string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

            bool isDealerOwner = await this.carService.IsDealerWithIdOwnerOfCarWithIdAsync(id, dealerId);

            if (!isDealerOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Dealer owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                CarPreDeleteDetailsViewModel viewModel = await this.carService.GetCarForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, CarPreDeleteDetailsViewModel formModel)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserDealer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an Dealer in order to edit car info!";

                return this.RedirectToAction("Become", "Dealer");
            }

            string dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.User.GetId()!);

            bool isDealerOwner = await this.carService.IsDealerWithIdOwnerOfCarWithIdAsync(id, dealerId);

            if (!isDealerOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Dealer owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                await this.carService.DeleteCarByIdAync(id);

                this.TempData[WarningMessage] = "The car was succsessfully deleted!";

                return this.RedirectToAction("Mine", "Car");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rent(string id)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool carRented = await this.carService.IsRentedAsync(id);

            if (carRented)
            {
                this.TempData[ErrorMessage] = "This car is already rented by another user! Please select different car.";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserDealer = await this.dealerService.DealerExistsByUserIdAsync(this.User.GetId()!);

            if (isUserDealer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "Dealers can't rent cars!";

                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                await this.carService.RentCarAsync(id, this.User.GetId()!);
            }
            catch (Exception)
            {
                this.GeneralError();
            }

            this.memoryCache.Remove(RentsCacheKey);

            return this.RedirectToAction("Mine", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            bool carExists = await this.carService.ExistCarByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool carRented = await this.carService.IsRentedAsync(id);

            if (!carRented)
            {
                this.TempData[ErrorMessage] = "This car is not rented!";

                return this.RedirectToAction("Mine", "Car");
            }

            bool isCurrentUserRenterOfCar = await this.carService.IsRentedByUserWithIdAsync(id, this.User.GetId()!);

            if (!isCurrentUserRenterOfCar)
            {
                this.TempData[ErrorMessage] = "You must be the renter of the car in order to leave it! Select any from yours cars.";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                await this.carService.LeaveCarAsync(id);
            }
            catch (Exception)
            {
                this.GeneralError();
            }

            this.memoryCache.Remove(RentsCacheKey);

            return this.RedirectToAction("Mine", "Car");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}