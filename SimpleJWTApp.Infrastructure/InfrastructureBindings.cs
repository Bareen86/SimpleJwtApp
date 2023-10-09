using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTTest.Application.Tokens;
using JWTTest.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace JWTTest.Infrastructure
{
    public static class InfrastructureBindings
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();
            return services;
        }
    }
}
