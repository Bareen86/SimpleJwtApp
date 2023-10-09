using JWTTest.Application.Tokens;
using JWTTest.Application.Tokens.CreateToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTest.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenConfiguration _tokenConfiguration;
        private readonly TokenCreator _tokenCreator;    

        public AuthenticationController(ITokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
            _tokenCreator = new TokenCreator( _tokenConfiguration );
        }

        [HttpGet("CreateAccessToken")]
        public IActionResult CreateAccessToken()
        {
            string accessToken = _tokenCreator.CreateAccessToken( 1 );
            return Ok( accessToken );
        }
    }
}
