namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Sedan"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Hatchback"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Coupe"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Convertible"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Station Wagon"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Sports Car"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Luxury Car"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "SUV (Sport Utility Vehicle)"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Minivan"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Pickup Truck"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 11,
                Name = "Off-Road"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}