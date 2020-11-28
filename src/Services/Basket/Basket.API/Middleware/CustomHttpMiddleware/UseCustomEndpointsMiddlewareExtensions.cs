using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace Basket.API.Middleware.CustomHttpMiddleware
{
    public static class UseCustomEndpointsMiddlewareExtensions
    {
        public static IEndpointRouteBuilder MapDistributedServices(this IEndpointRouteBuilder builder,
            IConfiguration configuration = null)
        {
            /*endpoints.MapGrpcService<BasketRepository>();*/
            return builder;
        }
    }
}