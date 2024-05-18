using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Specification;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface INewsFeedService
    {
        Task<IEnumerable<PostResultDto>> GetNewsFeedForUser(string userEmail , PostSpecificationParameters parameters);
    }
}
