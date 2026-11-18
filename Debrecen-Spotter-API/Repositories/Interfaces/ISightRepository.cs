using DebrecenSpotter.Api.Data.Models;

namespace DebrecenSpotter.Api.Repositories.Interfaces
{
    public interface ISightRepository
    {
        Task CreateSightAsync(Sight sight);
        Task DeleteSightAsync(Sight sight);
        Task DeleteSightByIdAsync(int id);
        Task UpdateSightAsync(Sight sight);
        Task AddLikeToSightAsync(int userId, int sightId);
        Task RemoveLikeFromSightAsync(int userId, int sightId);
        Task AddVisitAsync(int userId, int sightId);
        Task RemoveVisitAsync(int userId, int sightId);
        Task<Sight?> GetSightByIdAsync(int id);
        Task<IEnumerable<Sight>> GetTopSightsByLikesAsync(int count);
        Task<IEnumerable<Sight>> GetLikedSightsByUserIdAsync(int userId);
        Task<IEnumerable<Sight>> GetAllSightsAsync();
        Task<IEnumerable<Sight>> GetVisitedSightsByUserIdAsync(int userId);
    }
}