using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Seeding;

namespace SocialPulse.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountService> _logger;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, ILogger<AccountService> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<UserDto?> LoginAsync(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) return null;

            var userLogin = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (userLogin.Succeeded)
            {

                return new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    ProfileDescription = user.ProfileDescription,
                    ProfilePicture = $"{_configuration["BaseUrl"]}{user.ProfilePicture}",
                    Token = _tokenService.GenerateToken(user)
                };
            }
            return null;
        }

        public async Task<UserDto?> RegisterAsync(RegisterDto register)
        {
            try
            {
                var findEmail = await _userManager.FindByEmailAsync(register.Email);
                if (findEmail != null) return null;

                var user = new User
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Email = register.Email,
                    UserName = $"{register.FirstName}{register.LastName}",
                    ProfilePicture = register.ProfilePicture is null ? Defaults.ProfilePicture : register.ProfilePicture,
                };
                var res = await _userManager.CreateAsync(user, register.Password);
                if (res.Succeeded)
                {
                    return new UserDto
                    {
                        Email = register.Email,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        UserName = $"{register.FirstName}{register.LastName}",
                        ProfilePicture = $"{_configuration["BaseUrl"]}{user.ProfilePicture}",
                        Token = _tokenService.GenerateToken(user)
                    };
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred during user registration");

                // Return null or handle the exception as needed
                return null;
            }
            return null;
        }
    }
}
