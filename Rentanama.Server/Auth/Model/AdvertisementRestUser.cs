using Microsoft.AspNetCore.Identity;

namespace Rentanama.Server.Auth.Model
{
    public class AdvertisementRestUser : IdentityUser
    {
        [PersonalData]
        public string? AdditionalInfo { get; set; }
    }
}
