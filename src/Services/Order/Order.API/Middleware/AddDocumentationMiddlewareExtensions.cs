using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Order.API.Middleware
{
    public static class AddDocumentationMiddlewareExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Sooduskorv Order API",
                    Description = "Basket API documentation"
                });
            });
            return services;
        }
    }
}