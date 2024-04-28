using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialPulse.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name , user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            var credentials = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(claims),
                Audience = _configuration["Token:Audience"],
                Issuer = _configuration["Token:Issuer"],
                Expires = DateTime.Now.AddHours(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
