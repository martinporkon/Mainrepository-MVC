using System;
using Microsoft.AspNetCore.Builder;

namespace Sooduskorv_MVC.Middleware.ApiExceptionMiddleware
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder,
            Action<ApiExceptionOptions> configureOptions)
        {
            var options = new ApiExceptionOptions();
            configureOptions(options);
            return builder.UseMiddleware<ApiExceptionMiddleware>(options);
        }
    }
}