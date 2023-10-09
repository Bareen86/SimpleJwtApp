using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTTest.Application.Tokens.CreateToken
{
    public class TokenCreator
    {
        private readonly ITokenConfiguration _tokenConfiguration;

        public TokenCreator( ITokenConfiguration tokenConfiguration )
        {
            _tokenConfiguration = tokenConfiguration;
        }

        public string CreateAccessToken( int userId )
        {
            List<Claim> authClaim = new List<Claim>()
            {
                new Claim(nameof(userId), userId.ToString())
            };

            SymmetricSecurityKey signingKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _tokenConfiguration.GetSecretKey() ) );
            JwtSecurityToken token = new JwtSecurityToken(
                expires: DateTime.Now.AddSeconds( _tokenConfiguration.GetAccessTokenValidityInSeconds() ),
                claims: authClaim,
                signingCredentials: new SigningCredentials( signingKey, SecurityAlgorithms.HmacSha256 ) ); 
            return new JwtSecurityTokenHandler().WriteToken( token );
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
