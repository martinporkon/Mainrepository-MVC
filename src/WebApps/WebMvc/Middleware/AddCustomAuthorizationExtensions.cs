using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SooduskorvWebMVC.Middleware
{
    public static class AddCustomAuthorizationExtension
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    "AllowToOrderProductPolicy",
                    policyBuilder =>
                    {
                        policyBuilder.RequireAuthenticatedUser();
                        policyBuilder.RequireClaim("subscriptionlevel", "Basic");
                    });
            });
            return services;
        }
    }
}