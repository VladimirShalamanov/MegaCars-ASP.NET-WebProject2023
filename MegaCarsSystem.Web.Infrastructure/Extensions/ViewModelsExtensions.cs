namespace MegaCarsSystem.Web.Infrastructure.Extensions
{
    using MegaCarsSystem.Web.ViewModels.Category.Interfaces;

    public static class ViewModelsExtensions
    {
        public static string GetUrlInformation(this ICategoryDetailsModel model)
        {
            return model.Name.Replace(" ", "-");
        }
    }
}