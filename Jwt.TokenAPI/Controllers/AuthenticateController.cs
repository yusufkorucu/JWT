using Jwt.TokenAPI.Dto;
using Jwt.TokenAPI.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.TokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;

        public AuthenticateController(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        [HttpGet("GetToken")]
        public Dto.Token Auth()
        {
            return _tokenHandler.CreateToken();
        }
    }
}
