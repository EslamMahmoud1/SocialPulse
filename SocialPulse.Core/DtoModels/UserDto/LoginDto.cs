using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]        
        public string Password { get; set; }
    }
}
