namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AppUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("TestF");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("TestL");

            builder
                .HasOne(u => u.ShopCart)
                .WithOne(u => u.User)
                .HasForeignKey<ApplicationUser>(s => s.Id)
                .IsRequired();

            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> agentAndAdmin = new List<ApplicationUser>();
            
            ApplicationUser agentUser = new ApplicationUser()
            {
                Id = Guid.Parse(UserAgentId),
                Email = AgentEmail,
                NormalizedEmail = AgentEmail,
                UserName = AgentEmail,
                NormalizedUserName = AgentEmail,                FirstName = AgentFirstName,
                LastName = AgentLastName
            };
            agentUser.PasswordHash = hasher.HashPassword(agentUser, AgentPassword);
            agentUser.SecurityStamp = Guid.NewGuid().ToString();
            agentAndAdmin.Add(agentUser);

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse(Development_UserAdminId),
                Email = Development_AdminEmail,
                NormalizedEmail = Development_AdminEmail,
                UserName = Development_AdminEmail,
                NormalizedUserName = Development_AdminEmail,                FirstName = Development_AdminFirstName,
                LastName = Development_AdminLastName
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, Development_AdminPassword);
            adminUser.SecurityStamp = Guid.NewGuid().ToString();
            agentAndAdmin.Add(adminUser);

            return agentAndAdmin.ToArray();
        }
    }
}