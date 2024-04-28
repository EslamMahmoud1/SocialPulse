using AutoMapper;
using SocialPulse.Core.DtoModels;
using SocialPulse.Core.Interfaces;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;

namespace SocialPulse.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostDto> CreatePostAsync(PostDto post)
        {
            var mappedPost = _mapper.Map<Post>(post);
            if(mappedPost != null)
            {
                await _unitOfWork.Repository<Post, int>().AddAsync(mappedPost);
            }
            return post;
        }

        public void DeletePost(int id)
        {
            var post = _unitOfWork.Repository<Post, int>().GetByIdAsync(id);

        }

        public Task<PostDto> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> UpdatePostAsync(PostDto updatedPost)
        {
            throw new NotImplementedException();
        }
    }
}
