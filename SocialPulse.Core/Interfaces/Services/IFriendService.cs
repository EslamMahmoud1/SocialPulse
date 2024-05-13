using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IFriendService
    {

        Task<FriendToReturnDto> AddFriend(string requesterId, string addresseeId);

        Task<IEnumerable<FriendToReturnDto>> GetFriendRequests(string addresseeId);

        Task<IEnumerable<FriendToReturnDto>> GetFriendsList(string addresseeId);

        Task<FriendToReturnDto> RemoveFriend(string userId, string friendUserId);

        Task<FriendToReturnDto> AcceptFriend(string userId, string friendUserId);

        Task<FriendToReturnDto> DeclineFriend(string userId, string friendUserId);

    }
}
