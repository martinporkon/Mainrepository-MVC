using Sooduskorv_MVC.Middleware.LastRequestMiddleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestTrackingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTracking(this IApplicationBuilder builder)
        {
            var options = new RequestTrackingOptions();
            builder.UseMiddleware<RequestTrackingMiddleware>(options);
            return builder;
        }
    }
}