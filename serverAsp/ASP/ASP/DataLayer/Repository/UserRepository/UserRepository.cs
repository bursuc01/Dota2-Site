using ASP.DataLayer.Context;
using ASP.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataLayer.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _userContext;

        public UserRepository(DataContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext
                .Users
                .Include(e => e.HeroToUsers)
                .ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<int> GetUserIdByNameAsync(string name)
        {
            var user = await _userContext
                .Users
                .FirstOrDefaultAsync(elem => elem.Name == name);

            if (user != null)
            {
                return user.Id;
            }

            throw new Exception("User not found!"); // Return null if the user is not found
        }

        public async Task ModifyUserAsync(User user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(elem => elem.Id == id);

            if (user != null)
            {
                return user;
            }

            throw new Exception("User not found!"); // Return null if the user is not found
        }
    }
}
