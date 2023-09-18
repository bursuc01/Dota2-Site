using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;

namespace ASP.BusinessLogicLayer.HeroBLL
{
    public interface IHeroService
    {
        Task<IEnumerable<HeroDTO>> GetHeroesAsync();

        Task<HeroDTO> GetHeroByIdAsync(int id);

        Task ModifyHeroAsync(HeroDTO heroDTO);

        Task AddHeroAsync(HeroDTO heroDTO);

        Task DeleteHeroAsync(HeroDTO heroDTO);
        Task<IEnumerable<PowerDTO>> GetHeroPowersAsync(int heroid);
        Task PutPowerToUserAsync(int heroId, int powerId);
        public Task PutRolesToHeroAsync(int heroId, int rolesId);
        public Task PutStatsToHeroAsync(int heroId, int statsId);
    }
}
