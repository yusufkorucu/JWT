using Jwt.UserAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login")]
        public string Login()
        {
            return _userService.Auth();
        }


        [Authorize(AuthenticationSchemes ="API")]
        [HttpGet]
        public string UserInfo()
        {
            return "User Authorize Success";
        }
    }
}
