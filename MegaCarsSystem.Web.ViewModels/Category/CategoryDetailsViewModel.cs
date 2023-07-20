namespace MegaCarsSystem.Web.ViewModels.Category
{
    using MegaCarsSystem.Web.ViewModels.Category.Interfaces;

    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}