using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.DtoModels.UserDto
{
    public class FriendToReturnDto
    {
        public string? ProfilePicture { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? ProfileDescription { get; set; }
        [EmailAddress]
        public string Email { get; set; }


    }
}
