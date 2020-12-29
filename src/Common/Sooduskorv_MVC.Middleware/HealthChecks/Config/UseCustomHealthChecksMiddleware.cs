using Microsoft.AspNetCore.Builder;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks
{
    public static class UseCustomHealthChecksMiddleware
    {
        // TODO needs work
        public static void UseCustomHealthChecks(this IApplicationBuilder app)
        {
            /*app.MapWhen(// TODO <<--
                context => context.Request.Method == HttpMethod.Get.Method &&
                           context.Request.Path.StartsWith("/api/HealthCheck"),
                builder => builder.UseHealthChecks());*/
        }
    }
}