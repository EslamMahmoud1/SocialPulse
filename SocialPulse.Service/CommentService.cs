using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;

namespace SocialPulse.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        //create a comment for a certain post by a user 

        public async Task<CommentResultDto> CreateCommentAsync(string userEmail, int postId, CommentDto comment)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var commentCreated = new Comment()
            {
                User = user,
                UserId = user.Id,
                PostId = postId,
                Text = comment.Text,
                CreatedDate = DateTime.UtcNow,
            };

            await _unitOfWork.Repository<Comment, int>().AddAsync(commentCreated);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CommentResultDto>(commentCreated);
        }

        public Task<int> DeleteComment(string userID, int postId, int commentid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentResultDto>> GetAllCommentsAsync(int postId)
        {
            var post = await _unitOfWork.Repository<Post, int>().GetByIdAsync(postId);
            var comments = post.Comments;
            return _mapper.Map<IEnumerable<CommentResultDto>>(comments);
        }

        public Task<CommentResultDto> UpdateCommentAsync(string userEmail, int postId, int commentId, CommentDto updatedComment)
        {
            throw new NotImplementedException();
        }
    }
}
