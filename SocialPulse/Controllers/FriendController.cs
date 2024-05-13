using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("RequestsList")]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriendRequests(string userId)
        {
            return Ok(await _friendService.GetFriendRequests(userId));
        }

        [HttpGet("FriendsList")]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriendsList(string userId)
        {
            return Ok(await _friendService.GetFriendsList(userId));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Friend>> AddFriend(string requesterId, string addresseeId)
        {
            return Ok(await _friendService.AddFriend(requesterId, addresseeId));
        }

        [HttpPost("Accept")]
        public async Task<ActionResult<Friend>> AcceptFriend(string userId, string friendUserId)
        {
            return Ok(await _friendService.AcceptFriend(userId, friendUserId));
        }

        [HttpPost("Decline")]
        public async Task<ActionResult<Friend>> DeclineFriend(string userId, string friendUserId)
        {
            return Ok(await _friendService.DeclineFriend(userId, friendUserId));
        }

        [HttpPost("Remove")]
        public async Task<ActionResult<Friend>> RemoveFriend(string userId, string friendUserId)
        {
            return Ok(await _friendService.RemoveFriend(userId, friendUserId));
        }



    }
}
