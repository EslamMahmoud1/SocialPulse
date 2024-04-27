namespace SocialPulse.Core.Models
{
    public class Comment : BaseEntity<int>
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
