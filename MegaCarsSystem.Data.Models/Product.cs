namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Name_MaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(Description_MaxLength)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        [MaxLength(Image_MaxLength)]
        public string Image { get; set; } = null!;
    }
}