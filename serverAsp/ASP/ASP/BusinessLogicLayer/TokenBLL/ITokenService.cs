using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ASP.BusinessLogicLayer.TokenBLL
{
    public interface ITokenService
    {
        JwtSecurityToken CreateTokenOptions(User user);
        JwtSecurityToken CreateTokenOption();
    }
}
