using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class UseCustomEndpointsMiddlewareExtensions
    {
        public static IEndpointRouteBuilder MapServices(this IEndpointRouteBuilder builder,
            IConfiguration configuration)
        {
            /*endpoints.MapGrpcService<CatalogService.CatalogServiceClient>();*/
            /*endpoints.MapGrpcService<OrderService.OrderServiceClient>();
            endpoints.MapGrpcService<BasketService.BasketServiceClient>();*/
            return builder;
        }
    }
}