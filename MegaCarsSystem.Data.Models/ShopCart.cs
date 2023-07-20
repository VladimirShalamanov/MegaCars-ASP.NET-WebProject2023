namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShopCart
    {
        public ShopCart()
        {
            this.Id = Guid.NewGuid();
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Item> Items { get; set; }
    }
}