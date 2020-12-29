using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.Identity
{
    public static class AddCustomAuthorizationExtension
    {
        public static IServiceCollection AddCustomIdentityMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAccessTokenManagement();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("aaa", options =>
                {
                    options.Authority = "https://localhost:44318";
                    options.Audience = "mvc_gateway";
                });

            return services;
        }
    }
}