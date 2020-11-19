using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.DbContextMiddleware
{
    public static class AddCustomDbContextMiddlewareExtensions
    {
        public static IServiceCollection AddCustomDbContext<T>(this IServiceCollection services, IConfiguration configuration, string connectionString) where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(connectionString));
            });
            return services;
        }
    }
}