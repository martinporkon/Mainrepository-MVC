using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.Session
{
    public static class AddCustomSessionMiddlewareExtensions
    {
        public static IServiceCollection AddCustomSessions(this IServiceCollection services, IConfiguration g)
        {
            services.AddDistributedMemoryCache().AddSession(options =>
            {
                options.Cookie.Name = ".Sooduskorv.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            return services;
        }
    }
}