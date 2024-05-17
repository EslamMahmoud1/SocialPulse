using SocialPulse.Core.DtoModels.PostDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface INewsFeedService
    {
        Task<IEnumerable<PostResultDto>> GetNewsFeedForUser(string userEmail);
    }
}
