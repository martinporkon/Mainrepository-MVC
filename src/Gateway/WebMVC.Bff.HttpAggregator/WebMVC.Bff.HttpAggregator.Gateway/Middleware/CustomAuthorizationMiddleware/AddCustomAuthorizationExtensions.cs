using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers;

namespace SooduskorvWebMVC.Middleware
{
    public static class AddCustomAuthorizationExtension
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorizationHandler, UserForProductHandler>();
            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    "UserForProduct",
                    policyBuilder =>
                    {
                        policyBuilder.RequireAuthenticatedUser();
                        policyBuilder.AddRequirements(new UserForProductRequirement());
                    });
            });
            return services;
        }
    }
}