using System.ComponentModel.DataAnnotations;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }
        public string? ProfilePicture { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? ProfileDescription { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
