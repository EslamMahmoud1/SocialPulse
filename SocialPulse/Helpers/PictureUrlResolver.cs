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

        public class FriendPictureUrlResolver : IValueResolver<User, FriendToReturnDto, string>
        {
            private readonly IConfiguration _configuration;

            public FriendPictureUrlResolver(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string Resolve(User source, FriendToReturnDto destination, string destMember, ResolutionContext context)
            {
                return !string.IsNullOrEmpty(source.ProfilePicture) ? $"{_configuration["BaseUrl"]}{source.ProfilePicture}" : string.Empty;
            }
        }

    public class FriendPictureUrlResolverForRequester : IValueResolver<Friend, FriendToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public FriendPictureUrlResolverForRequester(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Friend source, FriendToReturnDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.Requester.ProfilePicture) ? $"{_configuration["BaseUrl"]}{source.Requester.ProfilePicture}" : string.Empty;
        }
    }

    public class FriendPictureUrlResolverForAddressee : IValueResolver<Friend, FriendToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public FriendPictureUrlResolverForAddressee(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Friend source, FriendToReturnDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.Addressee.ProfilePicture) ? $"{_configuration["BaseUrl"]}{source.Addressee.ProfilePicture}" : string.Empty;
        }
    }
}

