namespace MegaCarsSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.ViewModels.User;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllUsersAsync();

            return View(viewModel);
        }
    }
}