namespace MegaCarsSystem.Web.Areas.Admin.Controllers
{
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.ViewModels.Rent;
    using Microsoft.AspNetCore.Mvc;

    public class RentController : BaseAdminController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [Route("Rent/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<RentViewModel> allRents = await this.rentService.AllRentsAsync();

            return this.View(allRents);
        }
    }
}