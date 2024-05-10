using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Specifications;

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



        public async Task<int> DeleteComment(string userID, int postId, int commentid)
        {
            var user = await _userManager.FindByEmailAsync(userID);
            var comment = await GetCommentByIdAsync(commentid);

            if (comment.UserId != user.Id) throw new Exception("wrong user for comment id");

            _unitOfWork.Repository<Comment, int>().Delete(comment);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CommentResultDto>> GetAllCommentsAsync(int postId)
        {
            var spec = new PostSpec(postId);
            var post = await _unitOfWork.Repository<Post, int>().GetByIdWithSpecAsync(spec);
            var comments = post.Comments;
            return _mapper.Map<IEnumerable<CommentResultDto>>(comments);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await _unitOfWork.Repository<Comment, int>().GetByIdAsync(commentId);
            return comment;
        }

        public async Task<CommentResultDto> UpdateCommentAsync(string userEmail, int postId, int commentId, CommentDto updatedComment)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var comment = await GetCommentByIdAsync(commentId);

            if (comment.UserId != user.Id) throw new Exception("wrong user for comment id");

            comment.Text = updatedComment.Text;

            _unitOfWork.Repository<Comment, int>().Update(comment);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CommentResultDto>(comment);
        }
    }
}
