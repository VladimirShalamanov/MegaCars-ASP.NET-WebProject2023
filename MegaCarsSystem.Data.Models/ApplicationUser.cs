namespace MegaCarsSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.RentedCars = new HashSet<Car>();
        }

        public ShopCart? ShopCart { get; set; } = null!;

        public ICollection<Car> RentedCars { get; set; }
    }
}