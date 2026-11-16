using DebrecenSpotter.Api.Data.Models;

namespace DebrecenSpotter.Api.Repositories.Interfaces
{
    public interface ISightRepository
    {
        Task CreateSightAsync(Sight sight);
        Task DeleteSightAsync(Sight sight);
        Task DeleteSightByIdAsync(int Id);
        Task UpdateSightAsync(Sight sight);
        Task<Sight?> GetSightByIdAsync(int id);
        Task<IEnumerable<Sight>> GetTopSightsByLikesAsync(int count);
        Task<IEnumerable<Sight>> GetLikedSightssByUserIdAsync(int userId);
        Task<IEnumerable<Sight>> GetAllSightsAsync();
        Task<IEnumerable<Sight>> GetSightsByUserIdAsync(int userId);
        Task AddLikeToSightAsync(int userId, int sightId);
        Task RemoveLikeFromSightAsync(int userId, int sightId);
        Task AddVisitAsync(int userId, int sightId);
    }
}