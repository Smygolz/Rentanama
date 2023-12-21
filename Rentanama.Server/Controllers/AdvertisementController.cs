
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentanama.Server.Auth.Model;
using Rentanama.Server.Data.Dtos.Advertisements;
using Rentanama.Server.Data.Entities;
using Rentanama.Server.Data.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Rentanama.Server.Controllers
{

    [ApiController]
    [Route("api/advertisements")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAuthorizationService _authorizationService;
        public AdvertisementController(IAdvertisementRepository advertisementRepository, IAuthorizationService authorizationService) 
        {
            _advertisementRepository = advertisementRepository;
            _authorizationService = authorizationService;
        }
       
        [HttpGet]
        public async Task<IEnumerable<AdvertisementDto>> GetMany()
        {
            var advertisements = await _advertisementRepository.GetManyAsync();
       
            return advertisements.Select(o => new AdvertisementDto(o.Id, o.Name, o.CreationTime, o.Description));
        }

        // api/advertisements/{advertisementsId}
        [HttpGet]
        [Route("{advertisementId}", Name = "GetAdvertisement")]
        public async Task<ActionResult<AdvertisementDto>> Get(int advertisementId)
        {
            var advertisements = await _advertisementRepository.GetAsync(advertisementId);

            //If object is not found, 404 status code
            if (advertisements == null)
                return NotFound();
            
            return new AdvertisementDto(advertisements.Id,advertisements.Name, advertisements.CreationTime, advertisements.Description);
        }

        // api/advertisements
        [HttpPost]
        [Authorize(Roles = UserRoles.SystemUser)]
        public async Task<ActionResult<AdvertisementDto>> Create(CreateAdvertisementDto createAdvertisementDto)
        {

            var advertisement = new Advertisement
            {
                Name = createAdvertisementDto.Name,
                CreationTime= DateTime.UtcNow, 
                Description = createAdvertisementDto.Description,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };

           await _advertisementRepository.CreateAsync(advertisement);

            // Returns created object - 201
            return Created("", new AdvertisementDto(advertisement.Id, advertisement.Name, advertisement.CreationTime, advertisement.Description));

        }

        // api/advertisements
        [HttpPut]
        [Route("{advertisementId}")]
        [Authorize(Roles = UserRoles.SystemUser)]
        public async Task<ActionResult<AdvertisementDto>> Update(int advertisementId, UpdateAdvertisementDto updateAdvertisementDto)
        {
            var advertisements = await _advertisementRepository.GetAsync(advertisementId);

            //If object is not found, 404 status code
            if (advertisements == null)
                return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, advertisements, PolicyNames.ResourceOwner);
            if(!authorizationResult.Succeeded)
            {
                // 403
                return Forbid();
            }

            advertisements.Name = updateAdvertisementDto.Name;
            advertisements.Description = updateAdvertisementDto.Description;
            await _advertisementRepository.UpdateAsync(advertisements);
            // 200
            return Ok(new AdvertisementDto(advertisements.Id,advertisements.Name, advertisements.CreationTime, advertisements.Description));
        }

        [HttpDelete]
        [Route("{advertisementId}")]
        public async Task<ActionResult> Delete(int advertisementId)
        {
            var advertisements = await _advertisementRepository.GetAsync(advertisementId);

            //If object is not found, 404 status code
            if (advertisements == null)
                return NotFound();

            await _advertisementRepository.DeleteAsync(advertisements);

            // 204 - deleted
            return NoContent();
        }
    }
}
