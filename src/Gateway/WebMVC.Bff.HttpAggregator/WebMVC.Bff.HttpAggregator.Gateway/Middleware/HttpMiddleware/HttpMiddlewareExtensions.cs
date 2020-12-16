using Microsoft.AspNetCore.Mvc;
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
                configure.CacheProfiles.Add("SetCacheFor120",
                    new CacheProfile
                    {
                        Duration = 120,
                    });
            }).AddXmlDataContractSerializerFormatters()/*.AddCacheTagHelperLimits(new Action<CacheTagHelperOptions>())*/;
            return services;
        }
    }
}