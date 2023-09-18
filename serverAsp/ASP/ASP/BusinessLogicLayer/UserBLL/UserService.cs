using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using ASP.DataLayer.Repository.UserRepository;
using AutoMapper;

namespace ASP.BusinessLogicLayer.UserBLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,
            IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task AddUserAsync(UserDTO user)
        {
            await _userRepository.AddUserAsync(_mapper.Map<User>(user));
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.DeleteUserAsync(user);
        }

        public async Task<int> GetUserIdByNameAsync(string name)
        {
            return await _userRepository.GetUserIdByNameAsync(name);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task ModifyUserAsync(User user)
        {
            await _userRepository.ModifyUserAsync(user);
        }
    }
}
