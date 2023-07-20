namespace MegaCarsSystem.Web.ViewModels.Product
{
    public class AllProductViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;
    }
}