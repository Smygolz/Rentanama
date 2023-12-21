using Rentanama.Server.Data.Entities;

namespace Rentanama.Server.Data.Dtos.Apartments
{
        
   
        public record ApartmentDto(int Id, int SqaureMeters, int Cost, DateTime CreationTime, int Floor);
        public record CreateApartmentDto(int SquareMeters, int Cost, int Floor);
        public record UpdateApartmentDto(int SquareMeters, int Cost, int Floor);

}
