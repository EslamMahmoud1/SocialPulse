using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
