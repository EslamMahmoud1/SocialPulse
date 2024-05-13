using SocialPulse.Core.DtoModels.UserDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> GetUserByUsername(string username);
    }
}
