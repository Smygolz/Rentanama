using Rentanama.Server.Data.Entities;

namespace Rentanama.Server.Data.Repositories
{
    public interface IApartmentRepository
    {
       
            Task<Apartment> GetAllAsync(int advertisementId, int apartmentId);
            Task<List<Apartment>> GetAsync(int advertisementId);
            Task InsertAsync(Apartment apartment);
            Task UpdateAsync(Apartment apartment);
            Task DeleteAsync(Apartment apartment);
       
    }
}
