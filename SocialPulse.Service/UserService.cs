﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;

namespace SocialPulse.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

<<<<<<< Updated upstream
        public async Task<UserDto?> LoginAsync(LoginDto login)
=======
        public Task<string> ChangeFirstName(string oldFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeLastName(string oldFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeProfilePic(string oldProfilePic)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByIdAsync(string id)
>>>>>>> Stashed changes
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) return null;

            var userLogin = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!userLogin.Succeeded) return null;

            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.GenerateToken(user)
            };
        }

        public async Task<UserDto?> RegisterAsync(RegisterDto register)
        {
            var findEmail = await _userManager.FindByEmailAsync(register.Email);
            if (findEmail != null) return null;

            var user = new User
            {
                Email = register.Email,
                UserName = register.Email,
            };
            var res = await _userManager.CreateAsync(user,register.Password);
            if (!res.Succeeded) return null;

            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.GenerateToken(user)
            };
        }
    }
}
