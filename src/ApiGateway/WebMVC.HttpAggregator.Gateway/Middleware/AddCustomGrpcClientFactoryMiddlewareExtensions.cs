using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Order.Services;

namespace WebMVC.HttpAggregator.Gateway.Middleware
{
    public static class AddCustomGrpcClientFactoryMiddlewareExtensions
    {
        public static IServiceCollection AddCustomGrpcClientFactoryMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<CatalogService.CatalogServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:44366");
            });
            services.AddGrpcClient<OrderService.OrderServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:52277");
            });
            services.AddGrpcClient<BasketService.BasketServiceClient>(o =>
            {
                o.Address = new Uri("http://localhost:51690");
            });
            return services;
        }
    }
}