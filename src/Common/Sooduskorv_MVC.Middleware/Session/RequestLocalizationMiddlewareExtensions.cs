using System;
using Microsoft.AspNetCore.Builder;

namespace Sooduskorv_MVC.Middleware.Session
{
    public static class RequestLocalizationMiddlewareExtensions
    {
        /// <summary>
        /// Can only be used with chaining to app.UseRequestLocalization();
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static void WithCookies(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLocalizationMiddleware>();

        /// <summary>
        /// Can only be used with chaining to app.UseRequestLocalization();
        /// </summary>
        /// <param name="app"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IApplicationBuilder WithCookies(this IApplicationBuilder app,
            Action<RequestCLocalizationOptions> o)
            => app.UseMiddleware<RequestLocalizationMiddleware>(o);

    }
}