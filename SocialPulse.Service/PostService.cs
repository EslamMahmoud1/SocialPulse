using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces;
using SocialPulse.Core.DtoModels;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using Microsoft.AspNetCore.Http;
using SocialPulse.Service.Utility;
using SocialPulse.Core.Models.PostMedias;

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

        public async Task<PostResultDto> CreatePostAsync(string userEmail, PostDto post , IFormFile file)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            string folderName = file.ContentType.StartsWith("image/") ? "images" : "videos";
            MediaType type = file.ContentType.StartsWith("image/") ? MediaType.Image : MediaType.Video;

            var fileName = FileHandling.UploadPostFile(file, folderName);
            var postCreated = new Post()
            {
                UserId = user.Id,
                Content = post.Content,
                CreatedDate = DateTime.UtcNow,
                Media = new PostMedia ()
                {
                    FileName = file.FileName,
                    FilePath = fileName,
                    MediaType = type
                }
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
            var user = await _userManager.Users
                .Include(u => u.Posts)
                .ThenInclude(p => p.Comments)
                .SingleAsync(u => u.Email == userEmail);
            var allPosts = user.Posts;
            
            return _mapper.Map<IEnumerable<PostResultDto>>(allPosts);
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Post,int>().GetByIdAsync(id);
        }

        public async Task<PostResultDto> UpdatePostAsync(string userEmail,int postId, PostDto updatedPost)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var post = await GetPostByIdAsync(postId);
            if (post.UserId != user.Id) throw new Exception("wrong user for comment id");

            post.Content = updatedPost.Content;
            _unitOfWork.Repository<Post, int>().Update(post);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<PostResultDto>(post);
        }
    }
}
