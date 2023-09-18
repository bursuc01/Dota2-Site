using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;

namespace ASP.DataLayer.Repository.HeroToUserRepository
{
    public interface IHeroToUserRepository
    {

        public Task AddHeroToUserListAsync(HeroToUsers heroToUsers);

        public Task<IEnumerable<Hero>> GetHeroesFromUserListByIdAsync(int userId);

        public Task<IEnumerable<HeroToUsers>> GetHeroToUserByUserIdAsync(int userId);

        public Task DeleteHeroToUserAsync(HeroToUsers heroToUser);
    }
}
