namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.ShopCart;

    public interface IShopCartService
    {
        Task AddToCartByIdAsync(string userId, string productId);

        Task<bool> ExsistByIdAsync(string userId);

        Task CreateShopCartByIdAsync(string userId);

        Task<IEnumerable<ItemsForShopCartViewModel>> AllItemsForShopCartByIdAsync(string userId);
    }
}