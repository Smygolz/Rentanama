using Rentanama.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Rentanama.Server.Data.Dtos.Advertisements;
using Rentanama.Server.Data.Dtos.Apartments;

namespace Rentanama.Server.Data.Repositories
{
  
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly SystemDbContext _systemDbContext;
        
        public ApartmentRepository(SystemDbContext systemDbContext)
        {
            _systemDbContext = systemDbContext;
        }

        public async Task<Apartment?> GetAllAsync(int advertisementId, int apartmentId)
        {
            return await _systemDbContext.Apartments.FirstOrDefaultAsync(o => o.AdvertisementId == advertisementId && o.Id == apartmentId);
        }

        public async Task<List<Apartment>> GetAsync(int apartmentId)
        {
            return await _systemDbContext.Apartments.Where(o => o.Id == apartmentId).ToListAsync();
        }

        public async Task InsertAsync(Apartment apartment)
        {
            _systemDbContext.Apartments.Add(apartment);
            await _systemDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            _systemDbContext.Apartments.Update(apartment);
            await _systemDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Apartment apartment)
        {
            _systemDbContext.Apartments.Remove(apartment);
            await _systemDbContext.SaveChangesAsync();
        }

     
    }
}
