using AutoMapper;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Helpers
{
    public class PictureUrlResolver : IValueResolver<User, UserDto, string>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(User source, UserDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.ProfilePicture) ? $"{_configuration["BaseUrl"]}{source.ProfilePicture}" : string.Empty;
        }
    }
}
