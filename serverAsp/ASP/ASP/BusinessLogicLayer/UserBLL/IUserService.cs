using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;

namespace ASP.BusinessLogicLayer.UserBLL
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(UserDTO user);
        Task DeleteUserAsync(User user);
        Task<int> GetUserIdByNameAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task ModifyUserAsync(User user);
    }
}
