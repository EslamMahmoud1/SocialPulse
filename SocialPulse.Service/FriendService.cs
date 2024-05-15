using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Helpers;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Service
{
    public class FriendService : IFriendService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FriendService(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddFriendDto> AddFriend(string requesterId, string addresseeId)
        {
            var requester = await _userManager.FindByIdAsync(requesterId);
            var addressee = await _userManager.FindByIdAsync(addresseeId);

            if (requester == null || addressee == null)
            {
                throw new ArgumentException("One or both users not found.");
            }

            if (requester.Id == addressee.Id)
            {
                throw new ArgumentException("Users cannot be friends with themselves.");
            }

            var friend = new Friend
            {
                RequesterId = requester.Id,
                Requester = requester,
                AddresseeId = addressee.Id,
                Addressee = addressee,
                Status = FriendshipStatus.Pending
            };

            await _unitOfWork.FriendRepository().AddAsync(friend);
            await _unitOfWork.CompleteAsync(); // Assuming CompleteAsync saves changes

            return _mapper.Map<AddFriendDto>(friend);
        }

        public async Task<IEnumerable<FriendToReturnDto>> GetFriendRequests(string addresseeId)
        {
            var user = await _userManager.FindByIdAsync(addresseeId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var specs = new FriendSpecifications(f => f.AddresseeId == addresseeId && f.Status == FriendshipStatus.Pending);

            var requests = await _unitOfWork.FriendRepository().GetAllWithSpecsAsync(specs);

            var pendingRequests = requests.Select(x => x.Requester);

            return _mapper.Map<IEnumerable<FriendToReturnDto>>(pendingRequests);
        }

        public async Task<List<FriendToReturnDto>> GetFriendsList(string addresseeId)
        {
            var user = await _userManager.FindByIdAsync(addresseeId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var specs = new FriendSpecifications(f => (f.AddresseeId == addresseeId || f.RequesterId == addresseeId ) && f.Status == FriendshipStatus.Accepted);

            var list = await _unitOfWork.FriendRepository().GetAllWithSpecsAsyncc(specs);

            List<User>? friendsList = new List<User>();

            for ( int i = 0; i < list.Count; i++)
            {
                if (list[i].Requester == user)
                {
                    friendsList.Add( list[i].Addressee);
                }
                else
                {
                    friendsList.Add(list[i].Requester);
                }
            }

            return _mapper.Map<List<FriendToReturnDto>>(friendsList);
        }

        public async Task<FriendToReturnDto> RemoveFriend(string userId , string friendUserId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var friend = await _userManager.FindByIdAsync(friendUserId);

            if (user == null || friend == null)
            {
                throw new ArgumentException("One of the Users is not found.");
            }

            var specs = new FriendSpecifications(
                f => ((f.RequesterId == userId && f.AddresseeId ==friend.Id) || (f.AddresseeId == userId && f.RequesterId == friend.Id))
                    && (f.Status == FriendshipStatus.Accepted));

            var removedFriend = await _unitOfWork.FriendRepository().GetWithSpecsAsync(specs);

            removedFriend.Status = FriendshipStatus.Blocked;

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<FriendToReturnDto>(removedFriend);
        }

        public async Task<FriendToReturnDto> AcceptFriend(string userId, string friendUserId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var friend = await _userManager.FindByIdAsync(friendUserId);

            if (user == null || friend == null)
            {
                throw new ArgumentException("One of the Users is not found.");
            }

            var specs = new FriendSpecifications(
                f => ((f.RequesterId == userId && f.AddresseeId == friend.Id) || (f.AddresseeId == userId && f.RequesterId == friend.Id))
                    && (f.Status == FriendshipStatus.Pending));

            var acceptedFriend = await _unitOfWork.FriendRepository().GetWithSpecsAsync(specs);

            acceptedFriend.Status = FriendshipStatus.Accepted;

            await _unitOfWork.CompleteAsync();

            
            return _mapper.Map<FriendToReturnDto>(acceptedFriend);
        }

        public async Task<FriendToReturnDto> DeclineFriend(string userId, string friendUserId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var friend = await _userManager.FindByIdAsync(friendUserId);

            if (user == null || friend == null)
            {
                throw new ArgumentException("One of the Users is not found.");
            }

            var specs = new FriendSpecifications(
                f => ((f.RequesterId == userId && f.AddresseeId == friend.Id) || (f.AddresseeId == userId && f.RequesterId == friend.Id))
                    && (f.Status == FriendshipStatus.Pending));

            var declinedFriend = await _unitOfWork.FriendRepository().GetWithSpecsAsync(specs);

            declinedFriend.Status = FriendshipStatus.Declined;

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<FriendToReturnDto>(declinedFriend);
        }

    }
}
