using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPulse.Core.DtoModels.UserDto;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;

namespace SocialPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserByName(string userName)
        {
           return Ok(await _userService.GetUserByUsername(userName));
        }
    }
}
