using Microsoft.Extensions.DependencyInjection;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks
{
    public static class AddCustomHealthChecksMiddleware
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecksUI().AddInMemoryStorage();
            return services;
        }
    }
}