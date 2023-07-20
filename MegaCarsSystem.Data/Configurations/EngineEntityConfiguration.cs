namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    public class EngineEntityConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasData(this.GenerateEngines());
        }

        private Engine[] GenerateEngines()
        {
            ICollection<Engine> engines = new HashSet<Engine>();

            Engine engine;

            engine = new Engine()
            {
                Id = 1,
                Name = "Diesel"
            };
            engines.Add(engine);

            engine = new Engine()
            {
                Id = 2,
                Name = "Gasoline"
            };
            engines.Add(engine);

            return engines.ToArray();
        }
    }
}