using AutoMapper;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Helpers
{
    public class MediaUrlResolverForPost : IValueResolver<Post, PostResultDto, string>
    {
        private readonly IConfiguration _configuration;

        public MediaUrlResolverForPost(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Post source, PostResultDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.Media.FilePath) ? $"{_configuration["BaseUrl"]}{source.Media.FilePath}" : string.Empty;
        }
    }
}
