using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebMVC.HttpAggregator.Gateway.Middleware
{
    public static class AddDocumentationMiddlewareExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Sooduskorv Catalog API",
                    Description = "Catalog API documentation"
                });
            });
            return services;
        }
    }
}