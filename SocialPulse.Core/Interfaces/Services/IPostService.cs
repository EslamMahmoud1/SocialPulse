using Microsoft.AspNetCore.Http;
using SocialPulse.Core.DtoModels.PostDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IPostService
    {
        public Task<PostResultDto> CreatePostAsync(string userID, PostDto post ,IFormFile file);

        public Task<PostResultDto> GetPostByIdAsync(string userID, int id);
        public Task<IEnumerable<PostResultDto>> GetAllPostsAsync(string userID);

        public Task<PostResultDto> UpdatePostAsync(string userID, PostResultDto updatedPost);

        public Task<int> DeletePost(string userID, int id);
    }
}
