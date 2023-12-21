using AutoMapper;
using Rentanama.Server.Data.Dtos.Advertisements;
using Rentanama.Server.Data.Dtos.Apartments;
using Rentanama.Server.Data.Dtos.Cities;
using Rentanama.Server.Data.Entities;

namespace Rentanama.Server.Data
{
    public class MapperProfile : Profile
    {
     
        public MapperProfile() 
        {
            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<CreateAdvertisementDto, Advertisement>();
            CreateMap<UpdateAdvertisementDto, Advertisement>();

            CreateMap<Apartment, ApartmentDto>();
            CreateMap<CreateApartmentDto, Apartment>();
            CreateMap<UpdateApartmentDto, Apartment>();

            CreateMap<City, CitiesDto>();
            CreateMap<CreateCitiesDto, City>();
            CreateMap<UpdateCitiesDto, City>();
        }
    }
}
