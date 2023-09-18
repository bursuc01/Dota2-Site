using ASP.DataLayer.Models;

namespace ASP.DataLayer.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<int> GetUserIdByNameAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task ModifyUserAsync(User user);
    }
}
