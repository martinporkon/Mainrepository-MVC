using Catalog.API.HttpHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API
{
    public static class AddCustomGRpcMiddlewareExtensions
    {
        public static IServiceCollection AddCustomGRpc(this IServiceCollection services)
        {
            services.AddGrpc(opt =>
            {
                opt.EnableDetailedErrors = true;
            });
            return services;
        }
    }
}