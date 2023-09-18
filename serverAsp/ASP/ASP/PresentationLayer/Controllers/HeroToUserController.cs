using ASP.BusinessLogicLayer.HeroToUserBLL;
using ASP.BusinessLogicLayer.TokenBLL;
using ASP.BusinessLogicLayer.UserBLL;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace ASP.PresentationLayer.Controllers
{
    [Route("api/HeroToUser")]
    [ApiController]
    public class HeroToUserController : ControllerBase
    {
        private readonly IHeroToUserService _heroToUserService;
        public HeroToUserController(IHeroToUserService heroToUserService)
        {
            _heroToUserService = heroToUserService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHeroToUserList(HeroToUserDTO heroToUser)
        {
            await _heroToUserService.AddHeroToUserListAsync(heroToUser);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHeroToUser(
            [FromQuery] int heroId,
            [FromQuery] int userId)
        {
            var heroToUsers = await _heroToUserService.GetHeroToUserByUserIdAsync(userId);

            if(heroToUsers == null)
            {
                return NotFound("User not found");
            }

            var heroToUser = heroToUsers.FirstOrDefault(elem => elem.HeroId == heroId);

            await _heroToUserService.DeleteHeroToUserAsync(heroToUser);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroFromUserList(int userId)
        {
            var heroList = await _heroToUserService.GetHeroesFromUserListByIdAsync(userId);
            return Ok(heroList);
        }
    }
}
