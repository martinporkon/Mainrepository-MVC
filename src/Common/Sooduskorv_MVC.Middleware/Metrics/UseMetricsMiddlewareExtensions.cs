using Prometheus;

namespace Microsoft.AspNetCore.Builder
{
    public static class UseMetricsMiddlewareExtensions
    {
        public static IApplicationBuilder UseMetrics(this IApplicationBuilder app)
        {
            app.UseMetricServer(); 
            app.UseHttpMetrics();
            return app;
        }
    }
}