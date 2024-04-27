using Microsoft.AspNetCore.Identity;

namespace SocialPulse.Core.Models
{
    public class User : IdentityUser
    {
        public string? ProfileDescription { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Friend> Friends { get; set; } = new List<Friend>();
    }
}
