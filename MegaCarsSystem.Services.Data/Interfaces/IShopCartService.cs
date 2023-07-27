namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.ShopCart;

    public interface IShopCartService
    {
        Task AddToCartByIdAsync(string userId, string productId);

        Task RemoveFromCartByIdAsync(string userId, string itemId);

        Task<bool> ExistsItemByIdAsync(string itemId);

        Task<bool> ExistsShopCartByIdAsync(string userId);

        Task CreateShopCartByIdAsync(string userId);

        Task<IEnumerable<ItemsForShopCartViewModel>> AllItemsForShopCartByIdAsync(string userId);
    }
}