using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomDbContextMiddlewareExtensions
    {
        /// <summary>
        /// Register service. NB! Sooduskorv custom middleware.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        /// TODO vajab optione relational andmebaaside registreerimiseks. Ehk tuleb ümber teha.
        public static IServiceCollection AddCustomDbContext<T>(this IServiceCollection services, IConfiguration configuration, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(connectionString));
            });
            return services;
        }
    }
}