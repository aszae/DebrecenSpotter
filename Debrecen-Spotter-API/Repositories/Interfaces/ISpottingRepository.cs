using DebrecenSpotter.Api.Data.Models;

namespace DebrecenSpotter.Api.Repositories.Interfaces
{
    public interface ISpottingRepository
    {
        Task CreateSpottingAsync(Spotting spotting);
        Task DeleteSpottingAsync(Spotting spotting);
        Task DeleteSpottingByIdAsync(int Id);
        Task UpdateSpottingAsync(Spotting spotting);
        Task<Spotting?> GetSpottingByIdAsync(int id);
        Task<IEnumerable<Spotting>> GetAllSpottingsAsync();
        Task<IEnumerable<Spotting>> GetTopSpottingsByLikesAsync(int count);
        Task<IEnumerable<Spotting>> GetTodaysTopSpottingsByLikesAsync(int count);
        Task<IEnumerable<Spotting>> GetRecentSpottingsAsync(int count);
        Task<IEnumerable<Spotting>> GetTodaysSpottingsAsync();
        Task<IEnumerable<Spotting>> GetLikedSpottingsByUserIdAsync(int userId);
        Task<IEnumerable<Spotting>> GetSpottingsByUserIdAsync(int userId);
        Task AddLikeToSpottingAsync(int userId, int sightId);
        Task RemoveLikeFromSpottingAsync(int userId, int sightId);
    }
}