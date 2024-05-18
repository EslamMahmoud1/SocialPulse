using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.DtoModels.PostDto;
using SocialPulse.Core.Helpers;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Core.Specification;
using SocialPulse.Repository.Repos;
using SocialPulse.Repository.Specifications;
using System;

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

        public async Task<IEnumerable<PostResultDto>> GetNewsFeedForUser(string userEmail , PostSpecificationParameters parameters)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            var specs = new FriendSpecifications(f => (f.AddresseeId == user.Id || f.RequesterId == user.Id) && f.Status == FriendshipStatus.Accepted);

            var friends = await _unitOfWork.FriendRepository().GetAllWithSpecsAsyncc(specs);

            var allFriendUsers = new List<User>();
            
            foreach (var friend in friends)
            {
                var takenId = friend.AddresseeId != user.Id ? friend.AddresseeId : friend.RequesterId;

                allFriendUsers.Add(await _userManager.Users
                    .Include(u => u.Posts)
                    .ThenInclude(u => u.Comments)
                    .SingleAsync(u => u.Id == takenId));
            }
            var postList = new List<Post>();
            foreach (var friend in allFriendUsers)
            {
                postList.AddRange(friend.Posts);
            }

            IQueryable<Post> queryablePost = postList.AsQueryable();
            var spec = new NewsFeedSpecification(parameters);
            var ResultedPosts = SpecificationEvaluator<Post, int>.BuildQuery(queryablePost, spec);

            return _mapper.Map<IEnumerable<PostResultDto>>(ResultedPosts);
        }
    }
}
