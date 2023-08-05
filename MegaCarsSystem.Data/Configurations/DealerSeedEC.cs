namespace MegaCarsSystem.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class DealerSeedEC : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasData(GenerateDealerAndAdmin());
        }

        private Dealer[] GenerateDealerAndAdmin()
        {
            ICollection<Dealer> dealerAndAdmin = new HashSet<Dealer>();

            Dealer dealerUser = new Dealer()
            {
                Id = Guid.Parse(DealerId),
                PhoneNumber = "+359888777666",
                UserId = Guid.Parse(UserDealerId)
            };
            dealerAndAdmin.Add(dealerUser);

            Dealer adminUser = new Dealer()
            {
                Id = Guid.Parse(DealerAdminId_Development),
                PhoneNumber = "+359333222111",
                UserId = Guid.Parse(UserDealerId_Development)
            };
            dealerAndAdmin.Add(adminUser);

            return dealerAndAdmin.ToArray();
        }
    }
}