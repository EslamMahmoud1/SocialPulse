using SocialPulse.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.Models
{
    public class Friend : BaseEntity<int>
    {
        public string RequesterId { get; set; }
        public User Requester { get; set; } 

        public string AddresseeId { get; set; }
        public User Addressee { get; set; } 

        public FriendshipStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
