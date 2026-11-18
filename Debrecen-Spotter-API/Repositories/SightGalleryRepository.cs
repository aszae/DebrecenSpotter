using DebrecenSpotter.Api.Data;
using DebrecenSpotter.Api.Data.Models;
using DebrecenSpotter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebrecenSpotter.Api.Repositories
{
    public class SightGalleryRepository : ISightGalleryRepository
    {
        private readonly AppDbContext _dbContext;

        public SightGalleryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSightGalleryAsync(SightGallery sightGallery)
        {
            await _dbContext.SightGalleries.AddAsync(sightGallery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSightGalleryAsync(SightGallery sightGallery)
        {
            _dbContext.SightGalleries.Remove(sightGallery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSightGalleryByIdAsync(int id)
        {
            await _dbContext.SightGalleries
                .Where(sg => sg.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task UpdateSightGalleryAsync(SightGallery sightGallery)
        {
            _dbContext.SightGalleries.Update(sightGallery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SightGallery?> GetSightGalleryByIdAsync(int id)
        {
            return await _dbContext.SightGalleries.FindAsync(id);
        }

        public async Task<IEnumerable<SightGallery>> GetAllPicturesBySightIdAsync(int sightId)
        {
            return await _dbContext.SightGalleries
                .Where(sg => sg.SightId == sightId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SightGallery>> GetLatestPicturesAsync(int count)
        {
            return await _dbContext.SightGalleries
                .OrderByDescending(sg => sg.TimeOfCreation)
                .Take(count)
                .ToListAsync();
        }
        public async Task<IEnumerable<SightGallery>> GetLatestPicturesBySightIdAsync(int count, int sightId)
        {
            return await _dbContext.SightGalleries
                .Where(sg => sg.SightId == sightId)
                .OrderByDescending(sg => sg.TimeOfCreation)
                .Take(count)
                .ToListAsync();
        }
    }
}