namespace MegaCarsSystem.Services.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Web.ViewModels.Category;
    using MegaCarsSystem.Services.Data.Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly MegaCarsDbContext dbContext;

        public CategoryService(MegaCarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync()
        {
            IEnumerable<AllCategoriesViewModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new AllCategoriesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsCategoryByIdAsync(int id)
        {
            bool isFoundCategory = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return isFoundCategory;
        }

        public async Task<IEnumerable<CategoryForCarFormModel>> GetAllCategoriesAsync()
        {
            var allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new CategoryForCarFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == id);

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };

            return viewModel;
        }
    }
}