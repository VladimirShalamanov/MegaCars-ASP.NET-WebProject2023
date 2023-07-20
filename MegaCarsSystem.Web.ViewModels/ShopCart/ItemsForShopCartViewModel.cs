namespace MegaCarsSystem.Web.ViewModels.ShopCart
{
    public class ItemsForShopCartViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;
    }
}