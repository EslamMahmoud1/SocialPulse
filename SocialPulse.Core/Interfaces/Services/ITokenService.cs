using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
