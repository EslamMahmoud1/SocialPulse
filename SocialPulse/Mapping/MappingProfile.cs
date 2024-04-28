using AutoMapper;
using SocialPulse.Core.DtoModels;
using SocialPulse.Core.Models;

namespace SocialPulse.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post,PostDto>().ReverseMap();
        }
    }
}
