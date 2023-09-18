using ASP.DataLayer.Context;
using ASP.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataLayer.Repository.PowerRepository
{
    public class PowerRepository : IPowerRepository
    {
        private readonly DataContext _powerContext;
        public PowerRepository(DataContext powerContext) 
        {
            _powerContext = powerContext;
        }

        public async Task CreatePowerAsync(Power power)
        {
            await _powerContext.Powers.AddAsync(power);
            await _powerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            var powerList = await _powerContext.Powers.ToListAsync();
            return powerList;
        }

        public bool PowerExists(int id)
        {
            return (_powerContext.Powers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
