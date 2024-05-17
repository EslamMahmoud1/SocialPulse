using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Repos;
using SocialPulse.Repository.Specifications;

namespace SocialPulse.Service
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public NewsFeedService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostResultDto>> GetNewsFeedForUser(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            var specs = new FriendSpecifications(f => (f.AddresseeId == user.Id || f.RequesterId == user.Id));

            var friends = await _unitOfWork.FriendRepository().GetAllWithSpecsAsyncc(specs);

            var allFriendUsers = new List<User>();
            
            foreach (var friend in friends)
            {
                allFriendUsers.Add(await _userManager.Users
                    .Include(u => u.Posts)
                    .ThenInclude(u => u.Comments)
                    .SingleAsync(u => u.Email == friend.Addressee.Email));
            }
            var postList = new List<Post>();
            foreach (var friend in allFriendUsers)
            {
                postList.AddRange(friend.Posts);
            }
            postList.OrderBy(p => p.CreatedDate);

            return _mapper.Map<IEnumerable<PostResultDto>>(postList);
        }
    }
}
