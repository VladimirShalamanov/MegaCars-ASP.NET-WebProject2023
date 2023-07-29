namespace MegaCarsSystem.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Models;

    public class MegaCarsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MegaCarsDbContext(DbContextOptions<MegaCarsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<ShopCart> ShopCarts { get; set; } = null!;


        public DbSet<Gearbox> Gearboxes { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;


        public DbSet<Dealer> Dealers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MegaCarsDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}