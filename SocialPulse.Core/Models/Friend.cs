using SocialPulse.Core.Helpers;

namespace SocialPulse.Core.Models
{
    public class Friend
    {
        public string RequesterId { get; set; }
        public User Requester { get; set; }

        public string AddresseeId { get; set; }
        public User Addressee { get; set; }

        public FriendshipStatus Status { get; set; } = FriendshipStatus.NotDefined;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
