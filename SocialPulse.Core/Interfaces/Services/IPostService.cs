using Microsoft.AspNetCore.Http;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IPostService
    {
        public Task<PostResultDto> CreatePostAsync(string userID, PostDto post ,IFormFile file);

        public Task<Post> GetPostByIdAsync(int id);
        public Task<IEnumerable<PostResultDto>> GetAllPostsAsync(string userID);

        public Task<PostResultDto> UpdatePostAsync(string userID,int postId, PostDto updatedPost);

        public Task<int> DeletePost(string userID, int id);
    }
}
