using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentanama.Server.Auth;
using Rentanama.Server.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using static Rentanama.Server.Auth.Model.AuthDtos;

namespace Rentanama.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly UserManager<AdvertisementRestUser> _userManager;

        public AuthController(UserManager<AdvertisementRestUser> userManager, IJwtTokenService jwtTokenService) 
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (user != null)
                return BadRequest("Request invalid");

            var newUser = new AdvertisementRestUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName,
            };

           var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            // suceeded
            if(!createUserResult.Succeeded)
                return BadRequest(createUserResult.Errors);

            await _userManager.AddToRoleAsync(newUser, UserRoles.SystemUser);

            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
                return BadRequest("User name or passwork if invalid.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isPasswordValid)
            {
                return BadRequest("User name or password is invalid.");
            }
      

            // valid user
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

            return Ok(new SuccessfulLoginDto(accessToken));
        }

    }
}
