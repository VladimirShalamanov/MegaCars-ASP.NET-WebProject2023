namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Gearbox;

    public class Gearbox
    {
        public Gearbox()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GearName_MaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}