using Microsoft.EntityFrameworkCore;
using Rentanama.Server.Data.Entities;
namespace Rentanama.Server.Data.Repositories
{ 

public class CityRepository : ICityRepository
    {
    private readonly SystemDbContext _systemDbContext;

    public CityRepository(SystemDbContext systemDbContext)
    {
        _systemDbContext = systemDbContext;
    }

    public async Task<City?> GetAllAsync(int advertisementId, int apartmentId, int cityId)
    {
        return await _systemDbContext.Cities.FirstOrDefaultAsync(o => o.AdvertisementId == advertisementId && o.ApartmentId == apartmentId);
    }

    public async Task<List<City>> GetAsync(int advertisementId, int apartmentId)
    {
        return await _systemDbContext.Cities.Where(o => o.ApartmentId == apartmentId && o.AdvertisementId == advertisementId).ToListAsync();
    }

    public async Task InsertAsync(City city)
    {
        _systemDbContext.Cities.Add(city);
        await _systemDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(City city)
    {
        _systemDbContext.Cities.Update(city);
        await _systemDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(City city)
    {
        _systemDbContext.Cities.Remove(city);
        await _systemDbContext.SaveChangesAsync();
    }
}
}
