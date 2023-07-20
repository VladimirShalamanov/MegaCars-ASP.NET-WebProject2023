namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Product;

    public interface IProductService
    {
        Task<IEnumerable<AllProductViewModel>> AllProductsAsync();

        Task<bool> ExsistByIdAsync(string productId);

        Task<Product> GetProductByIdAsync(string productId);
    }
}