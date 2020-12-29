using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomDbContextMiddlewareExtensions
    {
        /// <summary>
        /// Register a database service here.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomDbContext<T>(this IServiceCollection services, IConfiguration configuration, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                // Todo for all
                options.UseSqlServer(configuration.GetConnectionString(connectionString));
            });
            return services;
        }
    }
}