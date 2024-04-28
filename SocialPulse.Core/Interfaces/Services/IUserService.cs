using SocialPulse.Core.DtoModels.UserDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDto?> LoginAsync(LoginDto login);
        public Task<UserDto?> RegisterAsync(RegisterDto register);
    }
}
