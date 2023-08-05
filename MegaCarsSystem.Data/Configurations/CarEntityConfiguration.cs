namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.Gearbox)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.GearboxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Engine)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.EngineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Dealer)
                .WithMany(a => a.OwnedCars)
                .HasForeignKey(a => a.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}