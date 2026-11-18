using DebrecenSpotter.Api.Data;
using DebrecenSpotter.Api.Data.Models;
using DebrecenSpotter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebrecenSpotter.Api.Repositories
{
    public class SightRepository : ISightRepository
    {
        private readonly AppDbContext _dbContext;

        public SightRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSightAsync(Sight sight)
        {
            await _dbContext.Sights.AddAsync(sight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSightAsync(Sight sight)
        {
            _dbContext.Sights.Remove(sight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSightByIdAsync(int id)
        {
            await _dbContext.Sights
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task UpdateSightAsync(Sight sight)
        {
            _dbContext.Sights.Update(sight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddLikeToSightAsync(int userId, int sightId)
        {
            var like = new SightLike
            {
                UserId = userId,
                SightId = sightId
            };

            await _dbContext.SightLikes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLikeFromSightAsync(int userId, int sightId)
        {
            await _dbContext.SightLikes
                .Where(sl => sl.UserId == userId && sl.SightId == sightId)
                .ExecuteDeleteAsync();
        }

        public async Task AddVisitAsync(int userId, int sightId)
        {
            var visit = new Visit
            {
                UserId = userId,
                SightId = sightId
            };

            await _dbContext.Visits.AddAsync(visit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveVisitAsync(int userId, int sightId)
        {
            await _dbContext.Visits
                .Where(v => v.UserId == userId && v.SightId == sightId)
                .ExecuteDeleteAsync();
        }

        public async Task<Sight?> GetSightByIdAsync(int id)
        {
            return await _dbContext.Sights.FindAsync(id);
        }

        public async Task<IEnumerable<Sight>> GetTopSightsByLikesAsync(int count)
        {
            return await _dbContext.Sights
                .OrderByDescending(s => s.SightLikes.Count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sight>> GetLikedSightsByUserIdAsync(int userId)
        {
            return await _dbContext.Sights
                .Where(s => s.SightLikes.Any(sl => sl.UserId == userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Sight>> GetAllSightsAsync()
        {
            return await _dbContext.Sights.ToListAsync();
        }

        public async Task<IEnumerable<Sight>> GetVisitedSightsByUserIdAsync(int userId)
        {
            return await _dbContext.Sights
                .Where(s => s.Visits.Any(v => v.UserId == userId))
                .ToListAsync();
        }
    }
}