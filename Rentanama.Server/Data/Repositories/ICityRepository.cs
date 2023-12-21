using Rentanama.Server.Data.Entities;

namespace Rentanama.Server.Data.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetAllAsync(int advertisementId, int apartmentId, int cityId);
        Task<List<City>> GetAsync(int advertisementId, int apartmentId);
        Task InsertAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(City city);
    }
}
