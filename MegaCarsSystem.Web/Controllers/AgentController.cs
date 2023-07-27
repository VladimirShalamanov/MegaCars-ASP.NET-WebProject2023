namespace MegaCarsSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MegaCarsSystem.Web.ViewModels.Agent;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationsMessagesConstants;

    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId!);

            if (isAgent)
            {
                this.TempData[ErrorMessage] = "You are already an agent!";

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId!);

            if (isAgent)
            {
                this.TempData[ErrorMessage] = "You are already an agent!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.agentService.AgentExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Agent with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasActiveRents = await this.agentService.HasRentsByUserIdAsync(userId!);

            if (userHasActiveRents)
            {
                this.TempData[ErrorMessage] = "You must not have any active rents in order to become an agent!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                await this.agentService.Create(userId!, model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            return this.RedirectToAction("All", "Car");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}