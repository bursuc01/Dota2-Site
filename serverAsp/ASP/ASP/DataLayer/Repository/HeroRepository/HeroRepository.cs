using ASP.DataLayer.Context;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataLayer.Repository.HeroRepository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _heroContext;

        public HeroRepository(DataContext heroContext)
        {
            _heroContext = heroContext;
        }

        public async Task AddHeroAsync(Hero hero)
        {
            await _heroContext.Heroes.AddAsync(hero);
            await _heroContext.SaveChangesAsync();

        }

        public async Task DeleteHeroAsync(Hero hero)
        {
            _heroContext.Heroes.Remove(hero);
            await _heroContext.SaveChangesAsync();
        }

        public async Task<Hero> GetHeroByIdAsync(int id)
        {
            var foundHero =  await _heroContext
                .Heroes
                .Include(hero => hero.PowerList)
                .Include(hero => hero.Stats)
                .Include(hero => hero.Roles)
                .FirstAsync(elem => elem.Id == id);
            if (foundHero == null)
            {
                throw new Exception("Hero not found");
            }

            return foundHero;
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            return await _heroContext
                .Heroes
                .Include(hero => hero.PowerList)
                .Include(hero => hero.Stats)
                .Include(hero => hero.Roles)
                .ToListAsync();
        }

        public async Task<IEnumerable<Power>> GetHeroPowersAsync(int heroId)
        {
            var hero = await _heroContext
                .Heroes
                .Include(h => h.PowerList)
                .FirstAsync(elem => elem.Id == heroId);

            return hero.PowerList;
        }

        public async Task ModifyHeroAsync(Hero hero)
        {
             _heroContext.Entry(hero).State = EntityState.Modified;
             await _heroContext.SaveChangesAsync();
        }

        public async Task PutPowerToHeroAsync(int heroId, int powerId)
        {
            var power = await _heroContext
                .Powers
                .FirstOrDefaultAsync(elem => elem.Id == powerId);
            
            if(power == null)
            {
                throw new EntryPointNotFoundException("Power not found!");
            }

            var hero = await _heroContext
                .Heroes
                .FirstOrDefaultAsync(elem => elem.Id == heroId);

            if (hero == null)
            {
                throw new EntryPointNotFoundException("Hero not found!");
            }

            power.HeroId = heroId;
            
            if(hero.PowerList == null)
            {
                hero.PowerList = new List<Power>();
            }

            hero.PowerList.Add(power);
            await _heroContext.SaveChangesAsync();
        }

        public async Task PutStatsToHeroAsync(int heroId, int statsId)
        {
            var stats = await _heroContext
                .Stats
                .FirstOrDefaultAsync(elem => elem.Id == statsId);

            if (stats == null)
            {
                throw new EntryPointNotFoundException("Power not found!");
            }

            var hero = await _heroContext
                .Heroes
                .FirstOrDefaultAsync(elem => elem.Id == heroId);

            if (hero == null)
            {
                throw new EntryPointNotFoundException("Hero not found!");
            }

            hero.Stats = stats;
            hero.StatsId = statsId; 
            stats.HeroId = heroId;
            stats.Hero = hero;
            
            await _heroContext.SaveChangesAsync();
        }

        public async Task PutRolesToHeroAsync(int heroId, int rolesId)
        {
            var roles = await _heroContext
                .Roles
                .FirstOrDefaultAsync(elem => elem.Id == rolesId);

            if (roles == null)
            {
                throw new EntryPointNotFoundException("Power not found!");
            }

            var hero = await _heroContext
                .Heroes
                .FirstOrDefaultAsync(elem => elem.Id == heroId);

            if (hero == null)
            {
                throw new EntryPointNotFoundException("Hero not found!");
            }

            hero.Roles = roles;
            hero.RoleId = rolesId;
            roles.HeroId = heroId;
            roles.Hero = hero;

            await _heroContext.SaveChangesAsync();
        }
    }
}
