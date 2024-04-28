using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Services;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(template:"login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _userService.LoginAsync(login);
            return user != null ? Ok(user) : Unauthorized(user);
        }



        [HttpPost(template:"register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var user = await _userService.RegisterAsync(register);
            return Ok(user);
        }
    }
}
