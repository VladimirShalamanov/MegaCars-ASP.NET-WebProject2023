namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.ShopCart;

    public interface IShopCartService
    {
        // Views
        Task<IEnumerable<ItemsForShopCartViewModel>> AllItemsForShopCartByIdAsync(string userId);

        // Func
        Task AddToCartByIdAsync(string userId, string productId);
        Task RemoveFromCartByIdAsync(string userId, string itemId);
        Task IncreaseQuantityWithOneByIdAsync(string userId, string itemId);

        // Check
        Task<bool> ExistsItemByIdAsync(string itemId);
        Task<bool> ExistsShopCartByIdAsync(string userId);

        // Create
        Task CreateShopCartByIdAsync(string userId);
    }
}