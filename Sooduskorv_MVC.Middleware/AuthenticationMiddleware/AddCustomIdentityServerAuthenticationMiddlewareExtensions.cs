using System;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.AuthenticationMiddleware
{
    public static class AddCustomIdentityServerAuthenticationMiddlewareExtensions
    {
        public static IServiceCollection AddCustomIdentityServerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options => throw new NotImplementedException());
            return services;
        }
    }
}