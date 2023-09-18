using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;

namespace ASP.BusinessLogicLayer.HeroToUserBLL
{
    public interface IHeroToUserService
    {
        public Task AddHeroToUserListAsync(HeroToUserDTO heroToUser);

        public Task<IEnumerable<Hero>> GetHeroesFromUserListByIdAsync(int userId);

        public Task<IEnumerable<HeroToUsers>> GetHeroToUserByUserIdAsync(int userId);

        public Task DeleteHeroToUserAsync(HeroToUsers heroToUser);
    }
}
