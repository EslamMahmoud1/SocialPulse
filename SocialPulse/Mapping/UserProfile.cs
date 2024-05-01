using AutoMapper;
using SocialPulse.API.Helpers;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDto>()
                .ForMember(destination => destination.ProfilePicture , options => options.MapFrom<PictureUrlResolver>());
        }
    }
}
