using System;
using Sooduskorv_MVC.Middleware.Performance;
using Sooduskorv_MVC.Middleware.RequestMiddleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestTimerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimer(this IApplicationBuilder app,
            Action<RequestTimerOptions> configureOptions)
        {
            return app.UseMiddleware<RequestTimerMiddleware>(configureOptions);
        }

        public static IApplicationBuilder UseRequestTimer(this IApplicationBuilder builder)
        {
            var options = new RequestTimerOptions();
            return builder.UseMiddleware<RequestTimerMiddleware>(options);
        }
    }
}