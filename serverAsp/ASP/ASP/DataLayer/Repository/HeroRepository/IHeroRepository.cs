using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;

namespace ASP.DataLayer.Repository.HeroRepository
{
    public interface IHeroRepository
    {
         public Task<IEnumerable<Hero>> GetHeroesAsync();

         public Task<Hero> GetHeroByIdAsync(int id);

        public Task ModifyHeroAsync(Hero hero); 

        public Task AddHeroAsync(Hero hero);

        public Task DeleteHeroAsync(Hero hero);
        Task<IEnumerable<Power>> GetHeroPowersAsync(int heroId);
        Task PutPowerToHeroAsync(int heroId, int powerId);
        public Task PutStatsToHeroAsync(int heroId, int statsId);
        public Task PutRolesToHeroAsync(int heroId, int rolesId);
    }
}
