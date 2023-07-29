namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Product;

    public interface IProductService
    {
        // Views
        Task<IEnumerable<AllProductViewModel>> AllProductsAsync();

        // Func
        Task<Product> GetProductByIdAsync(string productId);

        // Check
        Task<bool> ExistsProductByIdAsync(string productId);
    }
}