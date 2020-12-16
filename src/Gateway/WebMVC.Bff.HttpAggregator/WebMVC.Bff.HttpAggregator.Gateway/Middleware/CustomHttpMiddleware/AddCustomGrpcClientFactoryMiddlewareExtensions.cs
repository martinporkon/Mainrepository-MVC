using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class AddCustomGrpcClientFactoryMiddlewareExtensions
    {
        public static IServiceCollection AddCustomGrpcClientFactoryMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddGrpcClient<CatalogService.CatalogServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:44366");// TODO
            });*/
            /*services.AddGrpcClient<OrderService.OrderServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:52277");// TODO
            });*/
            /*services.AddGrpcClient<BasketService.BasketServiceClient>(o =>
            {
                o.Address = new Uri("http://localhost:51690"); ;// TODO
            });*/
            return services;
        }
    }
}