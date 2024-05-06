using SocialPulse.Core.DtoModels.UserDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<UserDto?> LoginAsync(LoginDto login);
        public Task<UserDto?> RegisterAsync(RegisterDto register);
    }
}
