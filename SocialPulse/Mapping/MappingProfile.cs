using AutoMapper;
using SocialPulse.API.Helpers;
using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post,PostDto>().ReverseMap();

            CreateMap<PostResultDto,Post>().ReverseMap()
                .ForMember(destination => destination.FilePath , options => options.MapFrom<MediaUrlResolverForPost>());

            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Comment,CommentResultDto>().ReverseMap();
            
        }
    }
}
