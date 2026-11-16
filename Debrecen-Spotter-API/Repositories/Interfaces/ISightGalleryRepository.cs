using DebrecenSpotter.Api.Data.Models;

namespace DebrecenSpotter.Api.Repositories.Interfaces
{
    public interface ISightGalleryRepository
    {
        Task CreateSightGalleryAsync(SightGallery sightGallery);
        Task DeleteSightGalleryAsync(SightGallery sightGallery);
        Task DeleteSightGalleryByIdAsync(int Id);
        Task UpdateSightGalleryAsync(SightGallery sightGallery);
        Task<IEnumerable<SightGallery>> GetAllPicturesBySightIdAsync(int sightId);
        Task<IEnumerable<SightGallery>> GetLatestPicturesAsync(int count);
    }
}