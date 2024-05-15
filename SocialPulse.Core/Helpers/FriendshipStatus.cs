using System.Text.Json.Serialization;

namespace SocialPulse.Core.Helpers
{
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FriendshipStatus
    {
       NotDefined ,Pending, Accepted, Declined, Blocked
    }
}
