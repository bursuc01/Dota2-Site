using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using ASP.DataLayer.Repository.HeroRepository;
using AutoMapper;

namespace ASP.BusinessLogicLayer.HeroBLL
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;
        public HeroService(IHeroRepository heroRepository,
            IMapper mapper) 
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HeroDTO>> GetHeroesAsync()
        {
            var heroList = await _heroRepository.GetHeroesAsync();
            return _mapper.Map<IEnumerable<HeroDTO>>(heroList);
        }

        public async Task<HeroDTO> GetHeroByIdAsync(int id)
        {
            var foundHero = await _heroRepository.GetHeroByIdAsync(id);
            return _mapper.Map<HeroDTO>(foundHero);
        }

        public async Task ModifyHeroAsync( HeroDTO heroDTO)
        {
            var heroToModify = _mapper.Map<Hero>(heroDTO);
            await _heroRepository.ModifyHeroAsync(heroToModify);
        }

        public async Task AddHeroAsync(HeroDTO heroDTO)
        {
            var hero = _mapper.Map<Hero>(heroDTO);
            hero.Stats = _mapper.Map<Stats>(heroDTO.Stats);
            hero.Roles = _mapper.Map<Roles>(heroDTO.Roles);
            await _heroRepository.AddHeroAsync(hero);
        }

        public async Task DeleteHeroAsync(HeroDTO heroDTO)
        {
            var heroToDelete = _mapper.Map<Hero>(heroDTO);
           await _heroRepository.DeleteHeroAsync(heroToDelete);
        }

        public async Task<IEnumerable<PowerDTO>> GetHeroPowersAsync(int heroId)
        {
            var powers = await _heroRepository.GetHeroPowersAsync(heroId);
            return _mapper.Map<IEnumerable<PowerDTO>>(powers);
        }

        public async Task PutPowerToUserAsync(int heroId, int powerId)
        {
            await _heroRepository.PutPowerToHeroAsync(heroId, powerId);
        }

        public async Task PutRolesToHeroAsync(int heroId, int rolesId)
        {
            await _heroRepository.PutRolesToHeroAsync(heroId, rolesId);
        }

        public async Task PutStatsToHeroAsync(int heroId, int statsId)
        {
            await _heroRepository.PutRolesToHeroAsync(heroId, statsId);
        }
    }
}
