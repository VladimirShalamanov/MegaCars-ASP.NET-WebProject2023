namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class CarSeedEC : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(GenerateCars());
        }

        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            Car car;

            car = new Car()
            {
                Brand = "Nissan",
                Model = "GT-R",
                YearOfManufacture = 2020,
                Horsepower = 565,
                EngineId = 2,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The 2020 GT-R's standard twin-turbo 3.8-liter V-6 makes a mighty 565 horsepower. It hooks up to a six-speed automatic transmission and all-wheel drive that conspire to put all that power to the pavement. At our test track, the GT-R launched itself from zero to 60 mph in a mere 2.9 seconds.",
                ImageUrl = "https://cdn.motor1.com/images/mgl/1MlwW/s1/2020-nissan-gt-r-nismo-review.jpg",
                PricePerDay = 800.00M,
                CategoryId = 6,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "Aston Martin",
                Model = "Vantage",
                YearOfManufacture = 2019,
                Horsepower = 503,
                EngineId = 2,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The Vantage is a rear wheel drive 2 door with 2 seats, powered by a 4.0L TWIN TURBO V8 engine that has 375 kW of power (at 6000 rpm) and 685 Nm of torque (at 2000 rpm) via an Eight-speed Automatic.",
                ImageUrl = "https://www.autocar.co.uk/sites/autocar.co.uk/files/1-aston-martin-vantage-2018-review-hero-front.jpg",
                PricePerDay = 1100.00M,
                CategoryId = 7,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "BMW",
                Model = "M5 Competition",
                YearOfManufacture = 2021,
                Horsepower = 600,
                EngineId = 2,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The M5 is powered by a 4.4-liter twin-turbo V-8 with 600 hp and 553 lb-ft of torque. M5 Competition models get a power bump to 617 hp. EPA fuel economy ratings are 15/21 mpg city/highway with the standard eight-speed automatic transmission. We've tested an M5 reaching 60 mph in as quick as 3.0 seconds.",
                ImageUrl = "https://www.thedrive.com/content/2021/09/IMG_3314.jpeg?quality=85&crop=16%3A9&auto=webp&optimize=high&quality=70&width=1440",
                PricePerDay = 1250.00M,
                CategoryId = 1,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "Audi",
                Model = "RS6 ",
                YearOfManufacture = 2022,
                Horsepower = 591,
                EngineId = 2,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The 2022 Audi RS6 Avant delivers a powerful performance with 591 horsepower, 590 lb-ft of torque, and only needs 3.5 seconds to go from 0-60 mph. The performance continues with quattro® sport rear wheel differential, RS-tuned air suspension, and ceramic brakes.",
                ImageUrl = "https://web2.wheelz.me/wp-content/uploads/2021/11/ABT_RS6-S_red_HR22_23.jpg",
                PricePerDay = 760.00M,
                CategoryId = 5,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "Mercedes",
                Model = "AMG G-63",
                YearOfManufacture = 2018,
                Horsepower = 563,
                EngineId = 1,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The high-performance AMG G63 is powered by a twin-turbo 5.5L V8 that makes 563 horsepower, making the big off-roader almost unnaturally quick. The AMG G65 is powered by a 6.0L twin-turbo V12 that produces 621 horsepower and 738 lb-feet of torque. All three engine options are mated to a 7-speed automatic transmission.",
                ImageUrl = "https://assets.autobuzz.my/wp-content/uploads/2018/11/13210055/2018-Mercedes-AMG-G-63-Launched-in-Malaysia-29.jpg",
                PricePerDay = 1490.00M,
                CategoryId = 11,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "Bentley",
                Model = "Continental GT",
                YearOfManufacture = 2021,
                Horsepower = 659,
                EngineId = 2,
                GearboxId = 2,
                Address = "ul. Ivan Vazov N3, Sofia, Bulgaria",
                Description = "The Continental measures 1405mm (55.3 inches) in height, 4850mm (190.9 inches) in length, 1966mm (77.4 inches) in width with a 2851mm (112.2 inches) wheelbase that brings about a total of 2244kg (4947.2 lbs) of unladen weight. The Continental GT comes standard with 265/40 ZR21 front tyres and 305/35 ZR21 rear tyres.",
                ImageUrl = "https://cdn.carbuzz.com/gallery-images/840x560/538000/900/538901.jpg",
                PricePerDay = 1230.00M,
                CategoryId = 4,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}