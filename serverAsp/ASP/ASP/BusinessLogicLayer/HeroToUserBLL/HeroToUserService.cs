using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using ASP.DataLayer.Repository.HeroRepository;
using ASP.DataLayer.Repository.HeroToUserRepository;
using AutoMapper;
using Microsoft.Identity.Client;

namespace ASP.BusinessLogicLayer.HeroToUserBLL
{
    public class HeroToUserService : IHeroToUserService
    {
        private readonly IHeroToUserRepository _heroToUserRepository;
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;
        public HeroToUserService(IHeroToUserRepository heroToUserRepository, 
            IHeroRepository heroRepository,
            IMapper mapper)
        {
            _heroToUserRepository = heroToUserRepository;
            _heroRepository = heroRepository;
            _mapper = mapper;
        }

        public async Task AddHeroToUserListAsync(HeroToUserDTO heroToUser)
        {
            await _heroToUserRepository.AddHeroToUserListAsync(_mapper.Map<HeroToUsers>(heroToUser));
        }

        public async Task<IEnumerable<Hero>> GetHeroesFromUserListByIdAsync(int userId)
        {
            return await _heroToUserRepository.GetHeroesFromUserListByIdAsync(userId);
        }

        public async Task<IEnumerable<HeroToUsers>> GetHeroToUserByUserIdAsync(int userId)
        {
            return await _heroToUserRepository.GetHeroToUserByUserIdAsync(userId);
        }

        public async Task DeleteHeroToUserAsync(HeroToUsers heroToUser)
        {
            await _heroToUserRepository.DeleteHeroToUserAsync(heroToUser);
        }

    }
}
