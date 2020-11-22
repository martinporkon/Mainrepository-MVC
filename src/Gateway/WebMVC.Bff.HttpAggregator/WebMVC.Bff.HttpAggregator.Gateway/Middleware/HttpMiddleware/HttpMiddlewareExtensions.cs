using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HttpMiddleware
{
    public static class HttpMiddlewareExtensions
    {
        public static IServiceCollection AddHttpMiddleware(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
                configure.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            return services;
        }
    }
}