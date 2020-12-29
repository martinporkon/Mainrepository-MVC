using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class UseCustomEndpointsMiddlewareExtensions
    {
        public static IEndpointRouteBuilder MapServices(this IEndpointRouteBuilder builder,
            IConfiguration configuration)
        {
            /*endpoints.MapGrpcService<CatalogService>();*/
            /*endpoints.MapGrpcService<OrderService>();
            endpoints.MapGrpcService<BasketService>();*/
            return builder;
        }
    }
}