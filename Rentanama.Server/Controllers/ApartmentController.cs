using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentanama.Server.Data.Dtos.Apartments;
using Rentanama.Server.Data.Dtos.Advertisements;
using Rentanama.Server.Data.Entities;
using Rentanama.Server.Data.Repositories;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Rentanama.Server.Auth.Model;

namespace Rentanama.Server.Controllers
{

    [ApiController]
    [Route("api/advertisements/{advertisementId}/apartments")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAuthorizationService _authorizationService;
        public ApartmentController(IApartmentRepository apartmentRepository, IAdvertisementRepository advertisementRepository, IAuthorizationService authorizationService) {
           _apartmentRepository = apartmentRepository;
           _advertisementRepository = advertisementRepository;
            _authorizationService = authorizationService;
           //_mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApartmentDto>> GetAllAsync(int apartmentId)
        {
            var apartments = await _apartmentRepository.GetAsync(apartmentId);
            return apartments.Select(o => new ApartmentDto(o.Id, o.SquareMeters, o.Cost, o.CreationDate, o.Floor));
        }


        [HttpGet]
        [Route("{apartmentId}")]
        public async Task<ActionResult<ApartmentDto>> GetAsync(int advertisementsId, int apartmentId)
        {
            var apartment = await _apartmentRepository.GetAllAsync(advertisementsId, apartmentId);
            if (apartment == null) return NotFound();

            return Ok(new ApartmentDto(apartment.Id, apartment.SquareMeters, apartment.Cost, apartment.CreationDate, apartment.Floor));
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.SystemUser)]
        public async Task<ActionResult<ApartmentDto>> PostAsync(int advertisementId, CreateApartmentDto apartmentDto) 
        {
            var advertisements = await _advertisementRepository.GetAsync(advertisementId);
            if (advertisements == null) return NotFound($"Couldn't find a advertisement with id of {advertisementId}");


            var apartment = new Apartment { SquareMeters = apartmentDto.SquareMeters, Cost = apartmentDto.Cost, Floor = apartmentDto.Floor };
            apartment.AdvertisementId = advertisementId;
            await _apartmentRepository.InsertAsync(apartment);
            return Created($"/api/advertisements/{advertisementId}/apartments/{apartment.Id}",
                new ApartmentDto(apartment.Id, apartment.SquareMeters, apartment.Cost, apartment.CreationDate, apartment.Floor));
        }

        [HttpPut]
        [Route("{apartmentId}")]
        [Authorize(Roles =UserRoles.SystemUser)]
        public async Task<ActionResult<ApartmentDto>> UpdateAsync(int advertisementsId, int apartmentId, UpdateApartmentDto apartmentDto)
        {
            var advertisement = await _advertisementRepository.GetAsync(advertisementsId);
            if (advertisement == null) return NotFound($"Couldn't find an advertisement with {advertisementsId}");

            var oldApartment = await _apartmentRepository.GetAllAsync(advertisementsId, apartmentId);
            if (oldApartment == null)
                return NotFound();

            oldApartment.SquareMeters = apartmentDto.SquareMeters;
            oldApartment.Cost = apartmentDto.Cost;
            oldApartment.Floor = apartmentDto.Floor;

            await _apartmentRepository.UpdateAsync(oldApartment);

            return Ok(new ApartmentDto(oldApartment.Id, oldApartment.SquareMeters, oldApartment.Cost, oldApartment.CreationDate, oldApartment.Floor));
        }


        [HttpDelete]
        [Route("{apartmentId}")]
        [Authorize(Roles=UserRoles.Admin)]
        public async Task<ActionResult> DeleteAsync(int advertisementsId, int apartmentId) 
        {
            var apartment = await _apartmentRepository.GetAllAsync(advertisementsId, apartmentId);
            if(apartment == null)
               return NotFound();

            await _apartmentRepository.DeleteAsync(apartment);

            return NoContent();
        }


    }

}
