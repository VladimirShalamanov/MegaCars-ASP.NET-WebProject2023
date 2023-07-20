namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Engine;

    public class Engine
    {
        public Engine()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EngineFuel_MaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}