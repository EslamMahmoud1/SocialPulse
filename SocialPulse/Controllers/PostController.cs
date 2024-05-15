using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces.Services;
using System.Security.Claims;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PostResultDto>>> GetAllPosts()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var posts = await _postService.GetAllPostsAsync(userEmail);
            return posts is not null ? Ok(posts) : throw new Exception("test ex") ;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostResultDto>> CreatePost([FromForm] PostDto input ,[FromForm] IFormFile file)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var posts = await _postService.CreatePostAsync(userEmail,input,file);
            return posts is not null ? Ok(posts) : throw new Exception("test ex");
        }


        [HttpDelete("{postId}")]
        [Authorize]
        public async Task<int> DeletePost(int postId)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return await _postService.DeletePost(userEmail, postId);
        }



        [HttpPut("{postId}")]
        [Authorize]
        public async Task<ActionResult<PostResultDto>> EditPost(int postId,PostDto input)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var res = await _postService.UpdatePostAsync(userEmail, postId, input);
            return res is not null ? Ok(res) : throw new Exception("test ex");
        }
    }
}
