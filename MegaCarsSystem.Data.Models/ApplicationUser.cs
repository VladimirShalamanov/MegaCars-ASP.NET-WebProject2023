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
        }

        [Required]
        [MaxLength(FirstName_MaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastName_MaxLength)]
        public string LastName { get; set; } = null!;

        public ShopCart? ShopCart { get; set; } = null!;

        public ICollection<Car> RentedCars { get; set; }
    }
}