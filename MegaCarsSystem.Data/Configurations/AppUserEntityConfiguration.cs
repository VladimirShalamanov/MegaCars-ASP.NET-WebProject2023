namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AppUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        //private readonly MegaCarsDbContext dbContext;

        //public AppUserEntityConfiguration(MegaCarsDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("TestF");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("TestL");

            builder
                .HasOne(e => e.ShopCart)
                .WithOne(e => e.User)
                .IsRequired();

            //if (!await this.dbContext.Users.AnyAsync(u => u.Email == GuestEmail))
            //{
            //}
            //builder.HasData(GenerateUsers());
        }

        //private ApplicationUser[] GenerateUsers()
        //{
        //    var hasher = new PasswordHasher<ApplicationUser>();

        //    ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

        //    ApplicationUser guestUser = new ApplicationUser()
        //    {
        //        Id = Guid.Parse("bc4be1b1-a70e-41bb-93b5-4920240f259a"),
        //        Email = GuestEmail,
        //        NormalizedEmail = GuestEmail,
        //        UserName = GuestEmail,
        //        NormalizedUserName = GuestEmail,        //        FirstName = GuestFirstName,
        //        LastName = GuestLastName
        //    };

        //    guestUser.PasswordHash = hasher.HashPassword(guestUser, GuestPassword);

        //    ApplicationUser agentUser = new ApplicationUser()
        //    {
        //        Id = Guid.Parse("83cae343-5b73-4c10-bac2-238264566a69"),
        //        Email = AgentEmail,
        //        NormalizedEmail = AgentEmail,
        //        UserName = AgentEmail,
        //        NormalizedUserName = AgentEmail,        //        FirstName = AgentFirstName,
        //        LastName = AgentLastName
        //    };

        //    agentUser.PasswordHash = hasher.HashPassword(agentUser, AgentPassword);

        //    //ApplicationUser adminUser = new ApplicationUser()
        //    //{
        //    //    Id = Guid.Parse("a5dd31b5-860f-4e43-bce8-9bdfc9f0f547"),
        //    //    Email = DevelopmentAdminEmail,
        //    //    NormalizedEmail = DevelopmentAdminEmail,
        //    //    UserName = DevelopmentAdminEmail,
        //    //    NormalizedUserName = DevelopmentAdminEmail,        //    //    FirstName = DevelopmentAdminFirstName,
        //    //    LastName = DevelopmentAdminLastName
        //    //};

        //    //adminUser.PasswordHash = hasher.HashPassword(adminUser, DevelopmentAdminPassword);

        //    users.Add(guestUser);
        //    users.Add(agentUser);
        //    //users.Add(adminUser);

        //    return users.ToArray();
        //}
    }
}