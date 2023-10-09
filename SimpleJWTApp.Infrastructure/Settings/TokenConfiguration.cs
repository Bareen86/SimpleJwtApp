using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTTest.Application.Tokens;
using Microsoft.Extensions.Configuration;

namespace JWTTest.Infrastructure.Settings
{
    public class TokenConfiguration : ITokenConfiguration
    {
        private readonly IConfiguration _configuration;

        public TokenConfiguration( IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public int GetAccessTokenValidityInSeconds()
        {
            string result = _configuration[ "JWTSettings:AccessTokeyValidityInSeconds" ];
            return int.Parse( result );
        }

        public int GetRefreshTokenValidityInDays()
        {
            string result = _configuration[ "JWTSettings:RefreshTokeyValidityInSeconds" ];
            return int.Parse( result );
        }

        public string GetSecretKey()
        {
            string result = _configuration[ "JWTSettings:Key" ];
            return result;
        }
    }
}
