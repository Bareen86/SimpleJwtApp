using System.IdentityModel.Tokens.Jwt;
using JWTTest.Application.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleJWTApp.Application.Tokens.DecodeToken;

namespace SimpleJWTApp.Api.Attributes
{
    public class JwtAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization( AuthorizationFilterContext context )
        {
            ITokenConfiguration tokenConfiguration = context.HttpContext.RequestServices.GetService<ITokenConfiguration>();

            string accessToken = context.HttpContext.Request.Headers[ "AccessToken" ];

            if ( accessToken is null )
            {
                context.Result = new ForbidResult();
            }

            TokenDecoder tokenDecoder = new TokenDecoder();
            JwtSecurityToken token = tokenDecoder.DecodeToker( accessToken );

            DateTime expDate = new DateTime( 1970, 1, 1 ).AddSeconds( ( token.Payload.Exp.Value ) ).AddHours( 3 );

            if ( DateTime.Now >= expDate )
            {
                context.Result = new ForbidResult();
            }
        }
    }
}   
