using DebrecenSpotter.Api.Data;
using DebrecenSpotter.Api.Data.Models;
using DebrecenSpotter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DebrecenSpotter.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<User?> FindUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetTopUsersByReceivedLikesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}