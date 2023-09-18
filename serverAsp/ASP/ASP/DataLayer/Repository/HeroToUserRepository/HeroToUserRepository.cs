using ASP.DataLayer.Context;
using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataLayer.Repository.HeroToUserRepository
{
    public class HeroToUserRepository : IHeroToUserRepository
    {
        private readonly DataContext _dataContext;

        public HeroToUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddHeroToUserListAsync(HeroToUsers heroToUsers)
        {
            // Save the HeroToUser bject into the DbSet
            await _dataContext.HeroToUsers.AddAsync(heroToUsers);
            // Save changes to the database
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hero>> GetHeroesFromUserListByIdAsync(int userId)
        {
            var query = from heroToUser in _dataContext.HeroToUsers
                        where heroToUser.UserId == userId
                        join hero in _dataContext.Heroes
                        on heroToUser.HeroId equals hero.Id
                        select hero;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<HeroToUsers>> GetHeroToUserByUserIdAsync(int userId)
        {
            return _dataContext.HeroToUsers.Where(elem => elem.UserId == userId);
        }


        public async Task DeleteHeroToUserAsync(HeroToUsers heroToUser)
        {
            _dataContext.HeroToUsers.Remove(heroToUser);
            await _dataContext.SaveChangesAsync();
        }
    }
}
