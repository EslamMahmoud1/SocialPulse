using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Services;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        [HttpPost(template:"login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _accountService.LoginAsync(login);
            return user != null ? Ok(user) : Unauthorized(user);
        }



        [HttpPost(template:"register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var user = await _accountService.RegisterAsync(register);
            return Ok(user);
        }
    }
}
