
using ASP.BusinessLogicLayer.UserBLL;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.PresentationLayer.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService heroService,
            IMapper mapper)
        {
            _userService = heroService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var heroes = await _userService.GetUsersAsync();

            if (heroes == null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> PostHero(UserDTO user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = _mapper.Map<User>(user).Id }, user);
        }

        // GET: api/User/{searchParameter}
        [HttpGet("FindUser")]
        public async Task<IActionResult> FindUserIdByName([FromQuery] string? name)
        {
            if (name != null)
            {
                var userId = await _userService.GetUserIdByNameAsync(name);
                return Ok(userId);
            }

            return NotFound();
        }

        // DELETE: api/User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(user);
            return Ok();
        }

        // PUT: api/User/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroes(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.ModifyUserAsync(user);

            return Ok();
        }
    }
}
