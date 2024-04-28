using System.ComponentModel.DataAnnotations;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
