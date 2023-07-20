namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Item;

    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Name_MaxLength)]
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(Image_MaxLength)]
        public string Image { get; set; } = null!;

        public Guid ShopCartId { get; set; }
        public ShopCart ShopCart { get; set; } = null!;
    }
}