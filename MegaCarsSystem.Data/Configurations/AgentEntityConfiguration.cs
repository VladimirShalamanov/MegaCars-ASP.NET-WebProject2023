//namespace MegaCarsSystem.Data.Configurations
//{
//    using System;

//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    using MegaCarsSystem.Data.Models;

//    using static Common.GeneralApplicationConstants;

//    public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
//    {
//        private readonly MegaCarsDbContext dbContext;

//        public AgentEntityConfiguration(MegaCarsDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public void Configure(EntityTypeBuilder<Agent> builder)
//        {
//            //if (!await this.dbContext.Users.AnyAsync(u => u.Email == GuestEmail))
//            //{
//            //}
//            builder.HasData(GenerateAgentAndAdminUsers());
//        }

//        private async Task<Agent[]> GenerateAgentAndAdminUsers()
//        {
//            var hasher = new PasswordHasher<ApplicationUser>();

//            ApplicationUser agent = await this.dbContext
//                .Users
//                .FirstAsync(u => u.Email == AgentEmail);

//            ApplicationUser admin = await this.dbContext
//                .Users
//                .FirstAsync(u => u.Email == DevelopmentAdminEmail);

//            ICollection<Agent> agentAndAdmin = new HashSet<Agent>();

//            Agent agentUser = new Agent()
//            {
//                Id = Guid.Parse("2d89dd05-07f3-435f-a143-bc1e3c06bdee"),
//                PhoneNumber = "+359888777666",
//                UserId = agent.Id
//            };

//            //Agent adminUser = new Agent()
//            //{
//            //    Id = Guid.Parse("5d782855-e7ca-40c8-82a0-37ce4f1fc991"),
//            //    PhoneNumber = "+359333222111",
//            //    UserId = admin.Id
//            //};

//            agentAndAdmin.Add(agentUser);
//            //agentAndAdmin.Add(adminUser);

//            return agentAndAdmin.ToArray();
//        }
//    }
//}
