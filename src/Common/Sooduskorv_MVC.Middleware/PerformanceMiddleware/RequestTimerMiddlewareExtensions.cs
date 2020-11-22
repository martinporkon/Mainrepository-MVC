using Sooduskorv_MVC.Middleware.Performance;
using Sooduskorv_MVC.Middleware.RequestMiddleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestTimerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimer(this IApplicationBuilder app,
            RequestTimerOptions configureOptions = null)
        {
            return app.UseMiddleware<RequestTimerMiddleware>(configureOptions);
        }
    }
}