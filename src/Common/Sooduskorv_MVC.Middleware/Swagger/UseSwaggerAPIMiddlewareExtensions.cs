using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    public static class UseSwaggerAPIMiddlewareExtensions
    {
        public static IApplicationBuilder UseSwaggerAPI(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Catalog V1");
            });
            return app;
        }
    }
}