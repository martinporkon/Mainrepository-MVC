using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace WebMVC.HttpAggregator.Gateway.Middleware
{
    public static class UseSwaggerAPIMiddlewareExtensions
    {
        public static IApplicationBuilder UseSwaggerAPI(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Catalog V1");
            });
            return app;
        }
    }
}