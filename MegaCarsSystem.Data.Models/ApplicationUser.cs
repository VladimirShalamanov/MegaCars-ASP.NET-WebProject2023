namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.RentedCars = new HashSet<Car>();
            this.Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(FirstName_MaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastName_MaxLength)]
        public string LastName { get; set; } = null!;

        public Guid? ShoppingCartId { get; set; }
        public ShopCart? ShoppingCart { get; set; }

        public ICollection<Car> RentedCars { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}