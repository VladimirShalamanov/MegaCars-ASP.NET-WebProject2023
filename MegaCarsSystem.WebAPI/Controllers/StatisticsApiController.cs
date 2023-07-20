namespace MegaCarsSystem.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Services.Data.Models.Statistics;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ICarService carService;

        public StatisticsApiController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel serviceModel = await this.carService.GetStatisticsAsync();

                return this.Ok(serviceModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}