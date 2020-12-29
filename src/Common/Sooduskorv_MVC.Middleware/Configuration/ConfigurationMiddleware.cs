using System;
//using System.Data.Entity.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sooduskorv_MVC.Middleware.Configuration
{
    public static class ConfigurationMiddleware
    {
        public static IServiceCollection AddCustomConfiguration<TSettings>(this IServiceCollection services, IConfiguration configuration) where TSettings : Settings
        {
            services.AddOptions();
            services.Configure<TSettings>(configuration);
            // + IOptions<TSettings> optionsAccessor
            /*services.TryAddSingleton<TSettings>();*/
            /*services.AddSingleton<TSettings>();*/
            /*services.AddSingleton(provider => new DbConnectionInfo { ConnectionString = provider.GetRequiredService<ApplicationSettings>().ConnectionString });*/
            return services;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services,
            IConfiguration configuration, params Settings[] s)
        {
            throw new NotImplementedException();
        }
    }
}