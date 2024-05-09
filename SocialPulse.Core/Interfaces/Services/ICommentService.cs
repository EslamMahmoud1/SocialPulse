using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface ICommentService
    {
        public Task<CommentResultDto> CreateCommentAsync(string userID, int postId, CommentDto comment);

        public Task<IEnumerable<CommentResultDto>> GetAllCommentsAsync(int postId);

        public Task<Comment> GetCommentByIdAsync(int commentId);

        public Task<CommentResultDto> UpdateCommentAsync(string userID, int postId, int commentId, CommentDto updatedComment);

        public Task<int> DeleteComment(string userID, int postId, int commentid);
    }
}
