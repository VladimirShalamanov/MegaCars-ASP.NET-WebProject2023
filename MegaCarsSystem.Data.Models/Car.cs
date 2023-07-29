namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MegaCarsSystem.Common;

    using static Common.EntityValidationConstants.Car;

    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Brand_MaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(Model_MaxLength)]
        public string Model { get; set; } = null!;

        [YearRange(YearOfManufacture_MinValue)]
        public int YearOfManufacture { get; set; }

        [Range(Horsepower_MinValue, Horsepower_MaxValue)]
        public int Horsepower { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; } = null!;

        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; } = null!;

        [Required]
        [MaxLength(Address_MaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(Description_MaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrl_MaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal PricePerDay { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Guid DealerId { get; set; }
        public Dealer Dealer { get; set; } = null!;

        public Guid? RenterId { get; set; }
        public ApplicationUser? Renter { get; set; } = null!;
    }
}