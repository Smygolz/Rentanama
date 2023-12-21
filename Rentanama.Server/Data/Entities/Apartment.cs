namespace Rentanama.Server.Data.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public int SquareMeters { get; set; }
        public int Cost { get; set; }
        public DateTime CreationDate { get; set; }
        public int Floor { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }
    }
}
