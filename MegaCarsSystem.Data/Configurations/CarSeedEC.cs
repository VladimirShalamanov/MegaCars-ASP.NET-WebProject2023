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
                Brand = "McLaren",
                Model = "720S",
                YearOfManufacture = 2016,
                Horsepower = 560,
                EngineId = 2,
                GearboxId = 2,
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This is a sports car and is recommended to be driven carefully.",
                ImageUrl = "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed",
                PricePerDay = 1500.00M,
                CategoryId = 6,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            car = new Car()
            {
                Brand = "Toyota",
                Model = "Supra",
                YearOfManufacture = 2020,
                Horsepower = 430,
                EngineId = 1,
                GearboxId = 1,
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "The car is a sports coupe type and is convenient for maneuvering in urban conditions.",
                ImageUrl = "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg",
                PricePerDay = 900.00M,
                CategoryId = 3,
                DealerId = Guid.Parse(DealerId)
            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}