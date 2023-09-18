using ASP.BusinessLogicLayer.TokenBLL;
using ASP.BusinessLogicLayer.UserBLL;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ASP.PresentationLayer.Controllers
{
    [Route("api/Authentificate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _authService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService,
              ITokenService authService,
              IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserDTO inputUser)
        {
            if (inputUser is null)
            {
                return BadRequest("Invalid client request");
            }

            // Get the list of users
            var userList = await _userService.GetUsersAsync();

            var foundUser = userList.FirstOrDefault(user =>
            (user.Name.Equals(inputUser.Name) || user.Email.Equals(inputUser.Email)) &&
            user.Password.Equals(inputUser.Password));

            if (foundUser == null)
            {
                return Unauthorized();
            }

            var userId = await _userService.GetUserIdByNameAsync(inputUser.Name);
            var user = await _userService.GetUserByIdAsync(userId);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(_authService.CreateTokenOptions(user));

            return Ok(new AuthenticatedResponseDTO { Token = tokenString });
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO inputUser)
        {
            if (inputUser is null)
            {
                return BadRequest();
            }


            var tokenString = new JwtSecurityTokenHandler().WriteToken(_authService.CreateTokenOption());
            
            await _userService.AddUserAsync(inputUser);
            return CreatedAtAction(nameof(Register), new { id = _mapper.Map<User>(inputUser).Id }, inputUser); ;
        }
    }
}
