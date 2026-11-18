using DebrecenSpotter.Api.Data;
using DebrecenSpotter.Api.Data.Models;
using DebrecenSpotter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebrecenSpotter.Api.Repositories
{
    public class SpottingRepository : ISpottingRepository
    {
        private readonly AppDbContext _dbContext;

        public SpottingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSpottingAsync(Spotting spotting)
        {
            await _dbContext.Spottings.AddAsync(spotting);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSpottingAsync(Spotting spotting)
        {
            _dbContext.Spottings.Remove(spotting);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSpottingByIdAsync(int id)
        {
            await _dbContext.Spottings
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task UpdateSpottingAsync(Spotting spotting)
        {
            _dbContext.Spottings.Update(spotting);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Spotting?> GetSpottingByIdAsync(int id)
        {
            return await _dbContext.Spottings.FindAsync(id);
        }

        public async Task<IEnumerable<Spotting>> GetAllSpottingsAsync()
        {
            return await _dbContext.Spottings.ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetTopSpottingsByLikesAsync(int count)
        {
            return await _dbContext.Spottings
                .OrderByDescending(s => s.SpottingLikes.Count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetTodaysTopSpottingsByLikesAsync(int count)
        {
            var today = DateTime.UtcNow.Date;

            return await _dbContext.Spottings
                .Where(s => s.TimeOfCreation >= today)
                .OrderByDescending(s => s.SpottingLikes.Count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetRecentSpottingsAsync(int count)
        {
            return await _dbContext.Spottings
                .OrderByDescending(s => s.TimeOfCreation)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetTodaysSpottingsAsync()
        {
            var today = DateTime.UtcNow.Date;

            return await _dbContext.Spottings
                .Where(s => s.TimeOfCreation >= today)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetLikedSpottingsByUserIdAsync(int userId)
        {
            return await _dbContext.Spottings
                .Where(s => s.SpottingLikes.Any(sl => sl.UserId == userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Spotting>> GetSpottingsByUserIdAsync(int userId)
        {
            return await _dbContext.Spottings
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task AddLikeToSpottingAsync(int userId, int spottingId)
        {
            var like = new SpottingLike
            {
                UserId = userId,
                SpottingId = spottingId
            };

            await _dbContext.SpottingLikes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLikeFromSpottingAsync(int userId, int spottingId)
        {
            await _dbContext.SpottingLikes
                .Where(sl => sl.UserId == userId && sl.SpottingId == spottingId)
                .ExecuteDeleteAsync();
        }
    }
}