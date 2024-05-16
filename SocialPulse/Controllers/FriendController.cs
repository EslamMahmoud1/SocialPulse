using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using System.Security.Claims;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly UserManager<User> _userManager;

        public FriendController(IFriendService friendService, UserManager<User> userManager)
        {
            _friendService = friendService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("RequestsList")]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriendRequests()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.GetFriendRequests(authenticatedUserId));
        }

        [Authorize]
        [HttpGet("FriendsList")]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriendsList()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.GetFriendsList(authenticatedUserId));
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult<AddFriendDto>> AddFriend(string addresseeId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.AddFriend(authenticatedUserId, addresseeId));
        }

        [Authorize]
        [HttpPost("Accept")]
        public async Task<ActionResult<FriendToReturnDto>> AcceptFriend(string friendUserId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.AcceptFriend(authenticatedUserId, friendUserId));
        }

        [Authorize]
        [HttpPost("Decline")]
        public async Task<ActionResult<FriendToReturnDto>> DeclineFriend(string friendUserId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.DeclineFriend(authenticatedUserId, friendUserId));
        }

        [Authorize]
        [HttpPost("Remove")]
        public async Task<ActionResult<FriendToReturnDto>> RemoveFriend(string friendUserId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var authenticatedUserId = user.Id;

            return Ok(await _friendService.RemoveFriend(authenticatedUserId, friendUserId));
        }
    }
}
