namespace MegaCarsSystem.Services.Data.Interfaces
{
    using MegaCarsSystem.Web.ViewModels.Category;

    public interface ICategoryService
    {
        // Views
        Task<IEnumerable<CategoryForCarFormModel>> GetAllCategoriesAsync();
        Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();
        Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);

        // Func
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        // Check
        Task<bool> ExistsCategoryByIdAsync(int id);
    }
}