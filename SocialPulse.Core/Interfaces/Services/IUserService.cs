using SocialPulse.Core.DtoModels.UserDto;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface IUserService
    {
<<<<<<< Updated upstream
        public Task<UserDto?> LoginAsync(LoginDto login);
        public Task<UserDto?> RegisterAsync(RegisterDto register);
=======
        public Task<UserDto> GetByIdAsync(string id);
        public Task<string> ChangeProfilePic(string oldProfilePic);
        public Task<string> ChangeFirstName(string oldFirstName);
        public Task<string> ChangeLastName(string oldFirstName);
>>>>>>> Stashed changes
    }
}
