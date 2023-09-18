using ASP.DataLayer.Models;

namespace ASP.DataLayer.Repository.PowerRepository
{
    public interface IPowerRepository
    {
        Task CreatePowerAsync(Power power);
        public Task<IEnumerable<Power>> GetAllPowersAsync();
        bool PowerExists(int id);
    }
}
