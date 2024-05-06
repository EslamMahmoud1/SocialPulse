using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces;
using SocialPulse.Core.DtoModels;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;

namespace SocialPulse.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PostResultDto> CreatePostAsync(string userEmail, PostDto post)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var postCreated = new Post()
            {
                UserId = user.Id,
                Content = post.Content,
                CreatedDate = DateTime.UtcNow,
            };

            await _unitOfWork.Repository<Post, int>().AddAsync(postCreated);
            await _unitOfWork.CompleteAsync();         
            return _mapper.Map<PostResultDto>(postCreated);
        }

        public async Task<int> DeletePost(string userEmail, int id)
        {
            var repository = _unitOfWork.Repository<Post, int>();
            var post = await repository.GetByIdAsync(id);
            repository.Delete(post);
            return await _unitOfWork.CompleteAsync(); 
        }

        public async Task<IEnumerable<PostResultDto>> GetAllPostsAsync(string userEmail)
        {
            var user = await _userManager.Users.Include(u => u.Posts).SingleAsync(u => u.Email == userEmail);
            var allPosts = user.Posts;
            return _mapper.Map<IEnumerable<PostResultDto>>(allPosts);
        }

        public async Task<PostResultDto> GetPostByIdAsync(string userEmail, int id)
        {
            var post = await _unitOfWork.Repository<Post,int>().GetByIdAsync(id);
            return _mapper.Map<PostResultDto>(post);
        }

        public async Task<PostResultDto> UpdatePostAsync(string userEmail, PostResultDto updatedPost)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var post = new Post()
            {
                Id = updatedPost.Id,
                UserId = user.Id,
                Content = updatedPost.Content,
                CreatedDate = DateTime.Now,
            };
            _unitOfWork.Repository<Post, int>().Update(post);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<PostResultDto>(post);
        }
    }
}
