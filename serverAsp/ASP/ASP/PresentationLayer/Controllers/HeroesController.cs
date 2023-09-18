using ASP.BusinessLogicLayer.HeroBLL;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ASP.PresentationLayer.Controllers
{
    [Route("api/Hero")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IActionResult> GetHeores()
        {
            var heroes = await _heroService.GetHeroesAsync();

            if(heroes == null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroById(int id)
        {
            var foundHero = await _heroService.GetHeroByIdAsync(id);

            if (foundHero == null)
            {
                return NotFound();
            }

            return Ok(foundHero);
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroes(int id, HeroDTO heroDTO)
        {

            await _heroService.ModifyHeroAsync(heroDTO);
         
            return Ok();
        }

        // POST: api/Heroes
        [HttpPost]
        public async Task<IActionResult> PostHeroes(HeroDTO heroDTO)
        {
            await _heroService.AddHeroAsync(heroDTO);
            return Ok(heroDTO);
        }

        [HttpGet("/GetPowers")]
        public async Task<IActionResult> GetHeroPowers(int heroId)
        {
            var heroPowers = await _heroService.GetHeroPowersAsync(heroId);
            
            if(heroPowers == null)
            {
                NotFound();
            }

            return Ok(heroPowers);
        }

        [HttpPost("/AssignPower")]
        public async Task<IActionResult> PutPowerToHero(int heroId, int powerId)
        {
            await _heroService.PutPowerToUserAsync(heroId, powerId);
            return Ok();
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroes(int id)
        {

            var hero = await _heroService.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            await _heroService.DeleteHeroAsync(hero);
            return NoContent();
        }

        

    }
}
