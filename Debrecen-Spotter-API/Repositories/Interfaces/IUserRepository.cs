using DebrecenSpotter.Api.Data.Models;

namespace DebrecenSpotter.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task DeleteUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task<User?> FindUserByIdAsync(int id);
        Task<User?> FindUserByNameAsync(string name);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetTopUsersByReceivedLikesAsync(int count);
    }
}