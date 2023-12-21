namespace Rentanama.Server.Data.Dtos.Advertisements
{
    public record AdvertisementDto(int Id, string Name, DateTime CreationDate, string Description);

    public record CreateAdvertisementDto(string Name, string Description);
    public record UpdateAdvertisementDto(string Name, string Description);
}
