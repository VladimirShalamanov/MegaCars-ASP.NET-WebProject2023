namespace MegaCarsSystem.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(GenerateAgentAndAdmin());
        }

        private Agent[] GenerateAgentAndAdmin()
        {
            ICollection<Agent> agentAndAdmin = new HashSet<Agent>();

            Agent agentUser = new Agent()
            {
                Id = Guid.Parse(AgentId),
                PhoneNumber = "+359888777666",
                UserId = Guid.Parse(UserAgentId)
            };
            agentAndAdmin.Add(agentUser);

            Agent adminUser = new Agent()
            {
                Id = Guid.Parse(Development_AgentAdminId),
                PhoneNumber = "+359333222111",
                UserId = Guid.Parse(Development_UserAdminId)
            };
            agentAndAdmin.Add(adminUser);

            return agentAndAdmin.ToArray();
        }
    }
}