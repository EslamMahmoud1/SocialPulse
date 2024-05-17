using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces.Services;
using System.Security.Claims;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly INewsFeedService _newsFeedService;

        public NewsFeedController(INewsFeedService newsFeedService)
        {
            _newsFeedService = newsFeedService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PostResultDto>>> GetNewsFeed()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var posts = await _newsFeedService.GetNewsFeedForUser(email);
            return Ok(posts);
        }
    }
}
