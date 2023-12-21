using System.Drawing;

namespace Rentanama.Server.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetAddress { get; set; }
        public string Region { get; set; }
        public int AdvertisementId { get; set; }
        public int ApartmentId { get; set; }

        public Apartment? Apartment { get; set; }

    }
}
