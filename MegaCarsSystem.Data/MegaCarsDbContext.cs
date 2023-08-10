namespace MegaCarsSystem.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Models;
    using MegaCarsSystem.Data.Configurations;

    public class MegaCarsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public MegaCarsDbContext(DbContextOptions<MegaCarsDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Gearbox> Gearboxes { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;


        public DbSet<Dealer> Dealers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<ShopCart> ShopCarts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Assembly configAssembly = Assembly.GetAssembly(typeof(MegaCarsDbContext)) ??
            //                          Assembly.GetExecutingAssembly();
            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.ApplyConfiguration(new AppUserEntityConfiguration());
            builder.ApplyConfiguration(new CarEntityConfiguration());
            builder.ApplyConfiguration(new ShopCartEntityConfiguration());
            builder.ApplyConfiguration(new ItemEntityConfiguration());
            builder.ApplyConfiguration(new OrderEntityConfiguration());

            builder.ApplyConfiguration(new AppUserSeedEC());
            builder.ApplyConfiguration(new DealerSeedEC());
            builder.ApplyConfiguration(new ShopCartSeedEC());

            //if (this.seedDb)
            //{

            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new GearboxEntityConfiguration());
            builder.ApplyConfiguration(new EngineEntityConfiguration());

            builder.ApplyConfiguration(new CarSeedEC());
            builder.ApplyConfiguration(new ProductSeedEC());

            //}

            base.OnModelCreating(builder);
        }
    }
}