using Microsoft.AspNetCore.Identity;
using Rentanama.Server.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace Rentanama.Server.Data.Entities
{
    public class Advertisement : IUserOwnedResource
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(3, ErrorMessage = "The minimal length of Name is 3 letters")]
        [MaxLength(50, ErrorMessage = "The maximal length of Name is 50 letters")]
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage="The minimal length of Description is 3 letters")]
        [MaxLength(100, ErrorMessage = "The maximal length of Description is 100 letters")]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public AdvertisementRestUser User { get; set; }

    }
}
