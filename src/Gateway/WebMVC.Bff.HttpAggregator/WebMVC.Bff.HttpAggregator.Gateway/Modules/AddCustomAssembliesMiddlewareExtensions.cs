using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.HttpAggregator.Gateway.Infrastructure;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomAssembliesMiddlewareExtensions
    {
        public static IServiceCollection AddCustomAssemblies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}