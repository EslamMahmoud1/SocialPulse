using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? ProfilePicture { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
