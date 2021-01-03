using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Sooduskorv_MVC.Aids.Constants;
using WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class AddCustomAuthorizationExtension
    {
        public static IServiceCollection AddCustomIdentityMiddleware(this IServiceCollection services)
        {
            services.AddAccessTokenManagement();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Security.GatewayAuthenticationScheme, options =>
                {
                    options.Authority = Security.Identity;
                    options.Audience = Security.GatewayAudience;
                });
            services.AddScoped<TokenExchangeHandler>();
            return services;
        }
    }
}