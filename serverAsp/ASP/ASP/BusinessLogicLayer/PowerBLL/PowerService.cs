using ASP.DataLayer.Models;
using ASP.DataLayer.Repository.PowerRepository;

namespace ASP.BusinessLogicLayer.PowerBLL
{
    public class PowerService : IPowerService
    {
        private readonly IPowerRepository _powerRepository;

        public PowerService(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        public async Task CreatePowerAsync(Power power)
        {
            await _powerRepository.CreatePowerAsync(power);
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            return await _powerRepository.GetAllPowersAsync();
        }

        public bool PowerExists(int id)
        {
            return _powerRepository.PowerExists(id);
        }
    }
}
