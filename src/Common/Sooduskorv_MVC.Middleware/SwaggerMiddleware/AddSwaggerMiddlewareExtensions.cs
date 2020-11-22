using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddSwaggerMiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Sooduskorv Catalog API",
                    Description = "konfiguratsioon not implemented"
                });
            });
            return services;
        }
    }
}