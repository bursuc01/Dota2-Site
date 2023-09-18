using Microsoft.AspNetCore.Mvc;
using ASP.DataLayer.Models;
using ASP.BusinessLogicLayer.PowerBLL;

namespace ASP.PresentationLayer.Controllers
{
    [Route("api/Power")]
    [ApiController]
    public class PowersController : Controller
    {
        private readonly IPowerService _powerService;

        public PowersController(IPowerService powerService)
        {
            _powerService = powerService;
        }

        // GET: Powers
        [HttpGet]
        public async Task<IActionResult> GetAllPowers()
        {
            var powerList = await _powerService.GetAllPowersAsync();
            if (powerList == null)
            {
                return NoContent();
            }
            return Ok(powerList);
        }
        // POST: Powers/Create
        [HttpPost]
        public async Task<IActionResult> PostPower(Power power)
        {
            await _powerService.CreatePowerAsync(power);
            return Ok();
        }

    }
}
