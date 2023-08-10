namespace MegaCarsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string EmailUser { get; set; } = null!;

        [Required]
        public string FullNameUser { get; set; } = null!;

        [Required]
        public string CityUser { get; set; } = null!;

        [Required]
        public string AddressUser { get; set; } = null!;

        [Required]
        public string PhoneNumberUser { get; set; } = null!;

        [Required]
        public string TotalPriceStrUser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}