using Microsoft.AspNetCore.Mvc;
using Rentanama.Server.Data.Dtos.Cities;
using Rentanama.Server.Data.Entities;
using Rentanama.Server.Data.Repositories;

namespace Rentanama.Server.Controllers
{
   
        [ApiController]
        [Route("api/advertisements/{advertisementId}/apartments/{apartmentId}/cities")]
        public class CityController : ControllerBase
        {
            private readonly IApartmentRepository _apartmentRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ICityRepository _cityRepository;
            //private readonly IMapper _mapper;

            public CityController(IApartmentRepository apartmentRepository, IAdvertisementRepository advertisementRepository, ICityRepository cityRepository)
            {
                _apartmentRepository = apartmentRepository;
                _advertisementRepository = advertisementRepository;
                _cityRepository = cityRepository;
                //_mapper = mapper;
            }

            [HttpGet]
            public async Task<IEnumerable<CitiesDto>> GetAllAsync(int advertisementId, int apartmentId)
            {
                var cities = await _cityRepository.GetAsync(advertisementId, apartmentId);
                return cities.Select(o => new CitiesDto(o.Id, o.CityName, o.StreetAddress, o.Region));
            }


            [HttpGet]
            [Route("{cityId}")]
            public async Task<ActionResult<CitiesDto>> GetAsync(int advertisementsId, int apartmentId, int cityId)
            {
                var cities = await _cityRepository.GetAllAsync(advertisementsId, apartmentId, cityId);
                if (cities == null) return NotFound();

                return Ok(new CitiesDto(cities.Id, cities.CityName, cities.StreetAddress, cities.Region));
            }

            [HttpPost]
            public async Task<ActionResult<CitiesDto>> PostAsync(int advertisementId, int apartmentId, CreateCitiesDto cityDto)
            {
                var advertisements = await _advertisementRepository.GetAsync(advertisementId);
                if (advertisements == null) return NotFound($"Couldn't find a advertisement with id of {advertisementId}");

                var apartments = await _apartmentRepository.GetAsync(apartmentId);
                if (apartments == null) return NotFound($"Couldn't find a apartments with id of {apartmentId}");


                var city = new City { CityName = cityDto.CityName, StreetAddress = cityDto.StreetAddress, Region = cityDto.Region };
                city.AdvertisementId = advertisementId;
                city.ApartmentId = apartmentId;

                await _cityRepository.InsertAsync(city);

                return Created($"/api/advertisements/{advertisementId}/apartments/{apartmentId}/city/{city.Id}",
                    new CitiesDto(city.Id, city.CityName, city.StreetAddress, city.Region));
            }

            [HttpPut]
            [Route("{cityId}")]
            public async Task<ActionResult<CitiesDto>> UpdateAsync(int advertisementsId, int apartmentId, int cityId, UpdateCitiesDto updateCitiesDto)
            {
                var advertisement = await _advertisementRepository.GetAsync(advertisementsId);
                if (advertisement == null) return NotFound($"Couldn't find an advertisement with {advertisementsId}");

                var apartment = await _apartmentRepository.GetAllAsync(advertisementsId, apartmentId);
                if (apartment == null) return NotFound($"Couldn't find an apartment with {apartmentId}");

                var city = await _cityRepository.GetAllAsync(advertisementsId, apartmentId, cityId);
                if (city == null) return NotFound();

                city.CityName = updateCitiesDto.CityName;
                city.StreetAddress = updateCitiesDto.StreetAddress;
                city.Region = updateCitiesDto.Region;

                await _cityRepository.UpdateAsync(city);

                return Ok(new CitiesDto(city.Id, city.CityName, city.StreetAddress, city.Region));
            }

            [HttpDelete]
            [Route("{cityId}")]
            public async Task<ActionResult> DeleteAsync(int advertisementsId, int apartmentId, int cityId)
            {
                var city = await _cityRepository.GetAllAsync(advertisementsId, apartmentId, cityId);
                if (city == null)
                    return NotFound();

                await _cityRepository.DeleteAsync(city);

                return NoContent();
            }

        }
    
}
