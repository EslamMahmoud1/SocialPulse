using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Specifications;

namespace SocialPulse.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public UserService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var specs = new UserSpecifications(username);
            var user = await _unitOfWork.UserRepository().GetWithSpecsAsync(specs);

            return _mapper.Map<UserDto>(user);
        }
    }
}
