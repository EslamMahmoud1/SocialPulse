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
            CreateMap<User, UserDto>()
                .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<PictureUrlResolver>());

            CreateMap<User, FriendToReturnDto>()
                .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<FriendPictureUrlResolver>());

            CreateMap<Friend, FriendToReturnDto>()
                .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<FriendPictureUrlResolverForRequester>())
                .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<FriendPictureUrlResolverForAddressee>())
                .ForMember(destination => destination.FirstName, o => o.MapFrom(s => s.Requester.FirstName))
                .ForMember(destination => destination.LastName, o => o.MapFrom(s => s.Requester.LastName))
                .ForMember(destination => destination.Email, o => o.MapFrom(s => s.Requester.Email))
                .ForMember(destination => destination.ProfileDescription, o => o.MapFrom(s => s.Requester.ProfileDescription));

            CreateMap<Friend, AddFriendDto>()
    .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<AddFriendPictureUrlResolverForRequester>())
    .ForMember(destination => destination.ProfilePicture, options => options.MapFrom<AddFriendPictureUrlResolverForAddressee>())
    .ForMember(destination => destination.FirstName, o => o.MapFrom(s => s.Addressee.FirstName))
    .ForMember(destination => destination.LastName, o => o.MapFrom(s => s.Addressee.LastName))
    .ForMember(destination => destination.Email, o => o.MapFrom(s => s.Addressee.Email))
    .ForMember(destination => destination.ProfileDescription, o => o.MapFrom(s => s.Requester.ProfileDescription));
        }
    }
}
