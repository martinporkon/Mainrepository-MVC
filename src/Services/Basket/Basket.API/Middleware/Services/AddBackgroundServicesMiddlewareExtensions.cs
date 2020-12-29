using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.BackgroundServiceMiddleware
{
    public static class AddBackgroundServicesMiddlewareExtensions
    {
        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            /*services.AddHostedService<MessageService>();*/
            return services;
        }
    }
}