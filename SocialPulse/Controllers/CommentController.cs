using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPulse.API.Controllers
{
    [Route("api/Post/{postId}/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentResultDto>>> GetAllComments(int postId)
        {
            var comments = await _commentService.GetAllCommentsAsync(postId);
            return comments is not null ? Ok(comments) : throw new Exception("test ex");
        }

        // POST api/<CommentController>

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentResultDto>> CreateComment(int postId,[FromBody] CommentDto input)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var comment = await _commentService.CreateCommentAsync(userEmail, postId, input);
            return comment is not null ? Ok(comment) : throw new Exception("test ex");
        }

        //PUT api/<CommentController>/5
        [HttpPut("{commentId}")]
        [Authorize]
        public async Task<ActionResult<CommentResultDto>> EditComment(int postId, int commentId, [FromBody] CommentDto input)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var comment = await _commentService.UpdateCommentAsync(userEmail, postId, commentId, input);
            return comment is not null ? Ok(comment) : throw new Exception("test ex");
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{commentId}")]
        [Authorize]
        public async Task<int> Delete(int postId, int commentId)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return await _commentService.DeleteComment(userEmail, postId, commentId);
        }
    }
}
