using Microsoft.EntityFrameworkCore;
using Rentanama.Server.Data.Dtos.Advertisements;
using Rentanama.Server.Data.Entities;

namespace Rentanama.Server.Data.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<Advertisement?> GetAsync(int id);
        Task<IReadOnlyList<Advertisement>> GetManyAsync();

        Task CreateAsync(Advertisement advertisement);
        Task UpdateAsync(Advertisement advertisement);
        Task DeleteAsync(Advertisement advertisement);
    }
    public class AdvertisementRepository : IAdvertisementRepository
    {

        private readonly SystemDbContext _systemDbContext;
        public AdvertisementRepository(SystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        /// <summary>
        /// Method that gets advertisement by id for one
        /// </summary>
        /// <param name="advertisementId">Takes advertisement id</param>
        /// <returns>Advertisement object or null</returns>
        public async Task<Advertisement?> GetAsync(int advertisementId)
        {
            return await _systemDbContext.Advertisements.FirstOrDefaultAsync(o => o.Id == advertisementId);
        }

        public async Task<IReadOnlyList<Advertisement>> GetManyAsync()
        {
            return await _systemDbContext.Advertisements.ToListAsync();
        }

        public async Task CreateAsync(Advertisement advertisement)
        {
            _systemDbContext.Advertisements.Add(advertisement);
            await _systemDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Advertisement advertisement)
        {
            _systemDbContext.Advertisements.Update(advertisement);
            await _systemDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Advertisement advertisement)
        {
            _systemDbContext.Advertisements.Remove(advertisement);
            await _systemDbContext.SaveChangesAsync();
        }
    }
}
