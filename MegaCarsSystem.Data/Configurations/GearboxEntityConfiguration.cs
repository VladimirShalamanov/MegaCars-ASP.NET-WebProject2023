namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    public class GearboxEntityConfiguration : IEntityTypeConfiguration<Gearbox>
    {
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.HasData(this.GenerateGearboxes());
        }

        private Gearbox[] GenerateGearboxes()
        {
            ICollection<Gearbox> gearboxes = new HashSet<Gearbox>();

            Gearbox gearbox;

            gearbox = new Gearbox()
            {
                Id = 1,
                Name = "Manual"
            };
            gearboxes.Add(gearbox);

            gearbox = new Gearbox()
            {
                Id = 2,
                Name = "Automatic"
            };
            gearboxes.Add(gearbox);

            return gearboxes.ToArray();
        }
    }
}