using System.IdentityModel.Tokens.Jwt;

namespace SimpleJWTApp.Application.Tokens.DecodeToken
{
    public  class TokenDecoder
    {
        public JwtSecurityToken DecodeToker(string accessToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadToken( accessToken ) as JwtSecurityToken;
            return token;
        }
    }
}
