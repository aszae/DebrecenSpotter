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

        public async Task<User?> FindUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        public async Task<User?> FindUserByNameAsync(string name)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == name);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
                
        }

        public async Task<IEnumerable<User>> GetTopUsersByReceivedLikesAsync(int count)
        {
            return await _dbContext.Users
                .OrderByDescending(u => u.Spottings.Sum(s => s.SpottingLikes.Count()))
                .Take(count)
                .ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}