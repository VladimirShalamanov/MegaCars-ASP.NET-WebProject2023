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


        public DbSet<Agent> Agents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MegaCarsDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            //ApplicationUser[] users = GenerateUsers();

            //builder
            //    .Entity<ApplicationUser>()
            //    .HasData(users);

            //builder
            //    .Entity<Agent>()
            //    .HasData(GenerateAgentAndAdminUsers(users[1]));

            base.OnModelCreating(builder);
        }

        //private ApplicationUser[] GenerateUsers()
        //{
        //    var hasher = new PasswordHasher<ApplicationUser>();

        //    ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

        //    ApplicationUser guestUser = new ApplicationUser()
        //    {
        //        Id = Guid.Parse("6435e52c-1508-46ae-b585-49c797a9e607"),
        //        Email = GuestEmail,
        //        NormalizedEmail = GuestEmail,
        //        UserName = GuestEmail,
        //        NormalizedUserName = GuestEmail,
        //        FirstName = GuestFirstName,
        //        LastName = GuestLastName
        //    };

        //    guestUser.PasswordHash = hasher.HashPassword(guestUser, GuestPassword);
        //    guestUser.SecurityStamp = Guid.NewGuid().ToString();

        //    ApplicationUser agentUser = new ApplicationUser()
        //    {
        //        Id = Guid.Parse("85ce132c-35cc-4b6a-8081-ec74aad74ea3"),
        //        Email = AgentEmail,
        //        NormalizedEmail = AgentEmail,
        //        UserName = AgentEmail,
        //        NormalizedUserName = AgentEmail,
        //        FirstName = AgentFirstName,
        //        LastName = AgentLastName
        //    };

        //    agentUser.PasswordHash = hasher.HashPassword(agentUser, AgentPassword);
        //    agentUser.SecurityStamp = Guid.NewGuid().ToString();

        //    ApplicationUser adminUser = new ApplicationUser()
        //    {
        //        Id = Guid.Parse("a5dd31b5-860f-4e43-bce8-9bdfc9f0f547"),
        //        Email = DevelopmentAdminEmail,
        //        NormalizedEmail = DevelopmentAdminEmail,
        //        UserName = DevelopmentAdminEmail,
        //        NormalizedUserName = DevelopmentAdminEmail,
        //        FirstName = DevelopmentAdminFirstName,
        //        LastName = DevelopmentAdminLastName
        //    };

        //    adminUser.PasswordHash = hasher.HashPassword(adminUser, DevelopmentAdminPassword);

        //    users.Add(guestUser);
        //    users.Add(agentUser);
        //    users.Add(adminUser);

        //    return users.ToArray();
        //}

        //private Agent GenerateAgentAndAdminUsers(ApplicationUser agent)
        //{
        //    ICollection<Agent> agentAndAdmin = new HashSet<Agent>();

        //    Agent agentUser = new Agent()
        //    {
        //        Id = Guid.Parse("8054bc54-c38b-4ba4-96ed-ea58995c326b"),
        //        PhoneNumber = "+359888777666",
        //        UserId = agent.Id
        //    };

        //    Agent adminUser = new Agent()
        //    {
        //        Id = Guid.Parse("5d782855-e7ca-40c8-82a0-37ce4f1fc991"),
        //        PhoneNumber = "+359333222111",
        //        UserId = admin.Id
        //    };

        //    agentAndAdmin.Add(agentUser);
        //    agentAndAdmin.Add(adminUser);

        //    return agentAndAdmin.ToArray();
        //    return agentUser;
        //}
    }
}