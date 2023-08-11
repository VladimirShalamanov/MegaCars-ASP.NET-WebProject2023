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
                Price = 5.99M,
                Image = "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg"
            };
            products.Add(product);

            product = new Product
            {
                Name = "T-shirt Supercar",
                Description = "Black T-shirt with great quality.",
                Price = 18.99M,
                Image = "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg"
            };
            products.Add(product);

            product = new Product
            {
                Name = "Cap Lamborghini",
                Description = "Blue Cap with great quality.",
                Price = 43.99M,
                Image = "https://cdn.shopify.com/s/files/1/1435/8030/products/LB17CAP2BL_Lamborghini_Blue_Cap_1.jpg?v=1657622166&width=533"
            };
            products.Add(product);

            product = new Product
            {
                Name = "Jacket Ferrari",
                Description = "Red Jacket with great quality.",
                Price = 89.99M,
                Image = "https://shopf1apparel.com/cdn/shop/products/Hd360c9d9c1a64a089d0f91a3266b17f0d.jpg?v=1630395464"
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}