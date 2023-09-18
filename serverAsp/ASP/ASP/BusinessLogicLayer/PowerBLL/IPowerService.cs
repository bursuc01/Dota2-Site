using ASP.DataLayer.Models;

namespace ASP.BusinessLogicLayer.PowerBLL
{
    public interface IPowerService
    {
        public Task<IEnumerable<Power>> GetAllPowersAsync();

        public Task CreatePowerAsync(Power power);

        public bool PowerExists(int id);
    }
}
