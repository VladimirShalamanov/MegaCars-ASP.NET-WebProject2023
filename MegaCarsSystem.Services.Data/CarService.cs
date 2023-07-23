﻿namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Car;
    using MegaCarsSystem.Web.ViewModels.Home;
    using MegaCarsSystem.Web.ViewModels.Agent;
    using MegaCarsSystem.Services.Data.Models.Car;
    using MegaCarsSystem.Web.ViewModels.Car.Enums;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Services.Data.Models.Statistics;

    public class CarService : ICarService
    {
        private readonly MegaCarsDbContext dbContext;
        private readonly IUserService userService;

        public CarService(MegaCarsDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public async Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel)
        {
            IQueryable<Car> carsQuery = this.dbContext
                .Cars
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Brand))
            {
                carsQuery = carsQuery
                    .Where(c => c.Brand == queryModel.Brand);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                carsQuery = carsQuery
                    .Where(c => c.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Engine))
            {
                carsQuery = carsQuery
                    .Where(e => e.Engine.Name == queryModel.Engine);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Gearbox))
            {
                carsQuery = carsQuery
                    .Where(e => e.Gearbox.Name == queryModel.Gearbox);
            }



            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                carsQuery = carsQuery
                    .Where(c => EF.Functions.Like(c.Brand, wildCard) ||
                                EF.Functions.Like(c.Model, wildCard) ||
                                EF.Functions.Like(c.Address, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard));
            }

            carsQuery = queryModel.CarSorting switch
            {
                CarSorting.Newest => carsQuery.OrderByDescending(c => c.CreatedOn),
                CarSorting.Oldest => carsQuery.OrderBy(c => c.CreatedOn),
                CarSorting.PriceAscending => carsQuery.OrderBy(c => c.PricePerDay),
                CarSorting.PriceDescending => carsQuery.OrderByDescending(c => c.PricePerDay),
                _ => carsQuery
                .OrderBy(c => c.RenterId != null)
                .ThenByDescending(c => c.CreatedOn)
            };

            IEnumerable<AllCarViewModel> allCars = await carsQuery
                .Where(c => c.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .Select(c => new AllCarViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.Brand,
                    Model = c.Model,
                    Address = c.Address,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId.HasValue
                })
                .ToArrayAsync();

            int totalCars = carsQuery.Count();

            return new AllCarsFilteredAndPagedServiceModel()
            {
                TotalCarsCount = totalCars,
                Cars = allCars
            };
        }

        public async Task<IEnumerable<string>> AllBrandNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Cars
                .OrderBy(c => c.Brand)
                .Select(c => c.Brand)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<IEnumerable<AllCarViewModel>> AllByAgentIdAsync(string agentId)
        {
            IEnumerable<AllCarViewModel> allAgentCars = await this.dbContext
                .Cars
                .Where(c => c.IsActive &&
                            c.AgentId.ToString() == agentId)
                .Select(c => new AllCarViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.Brand,
                    Model = c.Model,
                    Address = c.Address,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId.HasValue
                })
                .ToArrayAsync();

            return allAgentCars;
        }

        public async Task<IEnumerable<AllCarViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<AllCarViewModel> allUserCars = await this.dbContext
                .Cars
                .Where(c => c.IsActive &&
                            c.RenterId.HasValue &&
                            c.RenterId.ToString() == userId)
                .Select(c => new AllCarViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.Brand,
                    Model = c.Model,
                    Address = c.Address,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId.HasValue
                })
                .ToArrayAsync();

            return allUserCars;
        }

        public async Task<IEnumerable<IndexViewModel>> carsForIndexAsync()
        {
            IEnumerable<IndexViewModel> lastTwoCars = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                })
                .ToArrayAsync();

            return lastTwoCars;
        }

        public async Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string agentId)
        {
            Car newCar = new Car()
            {
                Brand = formModel.Brand,
                Model = formModel.Model,
                YearOfManufacture = formModel.YearOfManufacture,
                Horsepower = formModel.Horsepower,
                EngineId = formModel.EngineId,
                GearboxId = formModel.GearboxId,
                Address = formModel.Address,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                PricePerDay = formModel.PricePerDay,
                CategoryId = formModel.CategoryId,
                AgentId = Guid.Parse(agentId)
            };

            await this.dbContext.Cars.AddAsync(newCar);
            await this.dbContext.SaveChangesAsync();

            return newCar.Id.ToString();
        }

        public async Task<bool> ExistByIdAsync(string carId)
        {
            bool isFoundCar = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .AnyAsync(c => c.Id.ToString() == carId);

            return isFoundCar;
        }

        public async Task<CarFormModel> GetCarForEditByIdAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .Include(e => e.Engine)
                .Include(g => g.Gearbox)
                .Include(c => c.Category)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            return new CarFormModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                Horsepower = car.Horsepower,
                EngineId = car.EngineId,
                GearboxId = car.GearboxId,
                Address = car.Address,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                PricePerDay = car.PricePerDay,
                CategoryId = car.CategoryId
            };
        }

        public async Task EditCarByIdAndFormModelAsync(string carId, CarFormModel formModel)
        {
            Car car = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            car.Brand = formModel.Brand;
            car.Model = formModel.Model;
            car.YearOfManufacture = formModel.YearOfManufacture;
            car.Horsepower = formModel.Horsepower;
            car.EngineId = formModel.EngineId;
            car.GearboxId = formModel.GearboxId;
            car.Address = formModel.Address;
            car.Description = formModel.Description;
            car.ImageUrl = formModel.ImageUrl;
            car.PricePerDay = formModel.PricePerDay;
            car.CategoryId = formModel.CategoryId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .Include(e => e.Engine)
                .Include(g => g.Gearbox)
                .Include(c => c.Category)
                .Include(c => c.Agent)
                .ThenInclude(c => c.User)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            //ApplicationUser user = await this.dbContext
            //        .Users
            //        .FirstAsync(u => u.Email == email);

            //string fullName = $"{user.FirstName} {user.LastName}";

            return new CarDetailsViewModel()
            {
                Id = car.Id.ToString(),
                Brand = car.Brand,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                Horsepower = car.Horsepower,
                Engine = car.Engine.Name,
                Gearbox = car.Gearbox.Name,
                Address = car.Address,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                PricePerDay = car.PricePerDay,
                IsRented = car.RenterId.HasValue,
                Category = car.Category.Name,
                Agent = new AgentInfoOnCarViewModel()
                {
                    FullName = await this.userService.GetFullNameByEmailAsync(car.Agent.User.Email),
                    Email = car.Agent.User.Email,
                    PhoneNumber = car.Agent.PhoneNumber
                }
            };
        }

        public async Task<bool> IsAgentWithIdOwnerOfCarWithIdAsync(string carId, string agentId)
        {
            Car car = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            return car.AgentId.ToString() == agentId;
        }

        public async Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            return new CarPreDeleteDetailsViewModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                Address = car.Address,
                ImageUrl = car.ImageUrl
            };
        }

        public async Task DeleteCarByIdAync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == carId);

            car.IsActive = false;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRentedAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == carId);

            return car.RenterId.HasValue;
        }

        public async Task RentCarAsync(string carId, string userId)
        {
            Car car = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == carId);

            car.RenterId = Guid.Parse(userId);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRentedByUserWithIdAsync(string carId, string userId)
        {
            Car car = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == carId);

            return car.RenterId.HasValue &&
                   car.RenterId.ToString() == userId;
        }

        public async Task LeaveCarAsync(string carId)
        {
            Car car = await this.dbContext
                .Cars
                .FirstAsync(c => c.Id.ToString() == carId);

            car.RenterId = null;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalCars = await this.dbContext.Cars.CountAsync(),
                TotalRents = await this.dbContext
                                        .Cars
                                        .Where(c => c.RenterId.HasValue)
                                        .CountAsync()
            };
        }
    }
}