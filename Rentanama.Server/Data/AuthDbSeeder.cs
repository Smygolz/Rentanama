using Microsoft.AspNetCore.Identity;
using Rentanama.Server.Auth.Model;

namespace Rentanama.Server.Data
{
    public class AuthDbSeeder
    {
        private readonly UserManager<AdvertisementRestUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<AdvertisementRestUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager; 
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new AdvertisementRestUser
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "NotSafePassword1!");
                if(createAdminUserResult.Succeeded) 
                {
                    await _userManager.AddToRolesAsync(newAdminUser, UserRoles.All); 
                }
            }
        }

        private async Task AddDefaultRoles()
        {
            foreach(var role in UserRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if(!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));
                
            }
        }
    }
}
