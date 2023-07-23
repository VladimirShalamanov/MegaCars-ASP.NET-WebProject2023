namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Services.Data.Models.Car;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;

    [Authorize]
    public class CarController : Controller
    {
        private readonly IAgentService agentService;
        private readonly ICarService carService;
        private readonly IEngineService engineService;
        private readonly IGearboxService gearboxService;
        private readonly ICategoryService categoryService;

        public CarController(
            IAgentService agentService,
            ICarService carService,
            IEngineService engineService,
            IGearboxService gearboxService,
            ICategoryService categoryService)
        {
            this.agentService = agentService;
            this.carService = carService;
            this.engineService = engineService;
            this.gearboxService = gearboxService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel queryModel)
        {
            AllCarsFilteredAndPagedServiceModel serviceModel =
                await this.carService.AllAsync(queryModel);

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
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new cars!";

                return RedirectToAction("Become", "Agent");
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
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new cars!";

                return RedirectToAction("Become", "Agent");
            }

            bool engineExists = await this.engineService.ExistsByIdAsync(formModel.EngineId);

            if (!engineExists)
            {
                this.ModelState.AddModelError(nameof(formModel.EngineId), "Selected engine with type fuel does not exist!");
            }

            bool gearboxExists = await this.gearboxService.ExistsByIdAsync(formModel.GearboxId);

            if (!gearboxExists)
            {
                this.ModelState.AddModelError(nameof(formModel.GearboxId), "Selected gearbox does not exist!");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(formModel.CategoryId);

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
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

                string carId = await this.carService.CreateAndReturnIdAsync(formModel, agentId!);

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
            List<AllCarViewModel> myCars = new List<AllCarViewModel>();

            string userId = this.User.GetId()!;
            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(userId);

            try
            {
                if (this.User.IsAdmin())
                {
                    string agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);

                    myCars.AddRange(await this.carService.AllByAgentIdAsync(agentId));
                    myCars.AddRange(await this.carService.AllByUserIdAsync(userId));

                    myCars = myCars.DistinctBy(c => c.Id).ToList();
                }
                else if (isUserAgent)
                {
                    string agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);

                    myCars.AddRange(await this.carService.AllByAgentIdAsync(agentId));
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
            bool carExists = await this.carService.ExistByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            try
            {
                CarDetailsViewModel viewModel = await this.carService.GetDetailsByIdAsync(id);
                //viewModel.Agent.FullName

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
            bool carExists = await this.carService.ExistByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit car info!";

                return this.RedirectToAction("Become", "Agent");
            }

            string agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.carService.IsAgentWithIdOwnerOfCarWithIdAsync(id, agentId);

            if (!isAgentOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the car you want to edit!";

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

            bool carExists = await this.carService.ExistByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit car info!";

                return this.RedirectToAction("Become", "Agent");
            }

            string agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.carService.IsAgentWithIdOwnerOfCarWithIdAsync(id, agentId);

            if (!isAgentOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the car you want to edit!";

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
            bool carExists = await this.carService.ExistByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit car info!";

                return this.RedirectToAction("Become", "Agent");
            }

            string agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.carService.IsAgentWithIdOwnerOfCarWithIdAsync(id, agentId);

            if (!isAgentOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the car you want to edit!";

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
            bool carExists = await this.carService.ExistByIdAsync(id);

            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit car info!";

                return this.RedirectToAction("Become", "Agent");
            }

            string agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.carService.IsAgentWithIdOwnerOfCarWithIdAsync(id, agentId);

            if (!isAgentOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the car you want to edit!";

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
            bool carExists = await this.carService.ExistByIdAsync(id);

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

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "Agents can't rent cars!";

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

            return this.RedirectToAction("Mine", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            bool carExists = await this.carService.ExistByIdAsync(id);

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

            return this.RedirectToAction("Mine", "Car");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}