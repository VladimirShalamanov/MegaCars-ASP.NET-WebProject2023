namespace MegaCarsSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    using MegaCarsSystem.Common;
    using MegaCarsSystem.Web.ViewModels.Engine;
    using MegaCarsSystem.Web.ViewModels.Gearbox;
    using MegaCarsSystem.Web.ViewModels.Category;

    using static Common.EntityValidationConstants.Car;

    public class CarFormModel
    {
        public CarFormModel()
        {
            this.Engines = new HashSet<EngineForCarFormModel>();
            this.Gearboxes = new HashSet<GearboxForCarFormModel>();
            this.Categories = new HashSet<CategoryForCarFormModel>();
        }

        [Required]
        [StringLength(Brand_MaxLength, MinimumLength = Brand_MinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(Model_MaxLength, MinimumLength = Model_MinLength)]
        public string Model { get; set; } = null!;

        [YearRange(YearOfManufacture_MinValue)]
        public int YearOfManufacture { get; set; }

        [Range(Horsepower_MinValue, Horsepower_MaxValue)]
        public int Horsepower { get; set; }

        [Display(Name = "Select Engine")]
        public int EngineId { get; set; }
        public IEnumerable<EngineForCarFormModel> Engines { get; set; }

        [Display(Name = "Select Gearbox")]
        public int GearboxId { get; set; }
        public IEnumerable<GearboxForCarFormModel> Gearboxes { get; set; }

        [Required]
        [StringLength(Address_MaxLength, MinimumLength = Address_MinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(Description_MaxLength, MinimumLength = Description_MinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrl_MaxLength)]
        [Display(Name = "Link for Image")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PricePerDay_MinValue, PricePerDay_MaxValue)]
        [Display(Name = "Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Select Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryForCarFormModel> Categories { get; set; }
    }
}