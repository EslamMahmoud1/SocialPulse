using SocialPulse.Core.DtoModels;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IPostService
    {
        public Task<PostDto> CreatePostAsync(PostDto post);

        public Task<PostDto> GetPostById(int id);

        public Task<PostDto> UpdatePostAsync(PostDto updatedPost);

        public void DeletePost(int id);
    }
}
