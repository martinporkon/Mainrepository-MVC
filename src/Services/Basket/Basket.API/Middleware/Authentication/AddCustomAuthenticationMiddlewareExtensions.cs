using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.API.Middleware
{
    public static class AddCustomAuthenticationMiddlewareExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44318";
                    options.ApiName = "basketapi";
                    // TODO options.RequireHttpsMetadata = false;
                    options.ApiSecret = "apisecret";
                });
            return services;
        }
    }
}