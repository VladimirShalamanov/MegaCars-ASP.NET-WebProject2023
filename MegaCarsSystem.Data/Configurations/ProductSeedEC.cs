namespace MegaCarsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MegaCarsSystem.Data.Models;

    public class ProductSeedEC : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(GenerateProducts());
        }

        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new List<Product>();

            Product product;

            product = new Product
            {
                Name = "Keychain Turbine",
                Description = "Мetal key holder for your keys.",
                Price = 5.00M,
                Image = "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg"
            };
            products.Add(product);

            product = new Product
            {
                Name = "T-shirt Supercar",
                Description = "Black T-shirt with great quality.",
                Price = 18.00M,
                Image = "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg"
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}