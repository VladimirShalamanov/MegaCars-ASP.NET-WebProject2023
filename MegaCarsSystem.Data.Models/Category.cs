namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Name_MaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}