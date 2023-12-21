namespace Rentanama.Server.Data.Dtos.Cities
{

        public record CitiesDto(int Id, string CityName, string StreetAddress, string Region);
        public record CreateCitiesDto(string CityName, string StreetAddress, string Region);
        public record UpdateCitiesDto(string CityName, string StreetAddress, string Region);

   
}
