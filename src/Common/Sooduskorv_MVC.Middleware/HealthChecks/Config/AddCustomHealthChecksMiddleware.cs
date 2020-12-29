using System;
using Grpc.HealthCheck;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Sooduskorv_MVC.Aids.Constants;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks
{
    public static class AddCustomHealthChecksMiddleware
    {
        /// <summary>
        /// gRPC Health Checks without DbContext support for Sooduskorv custom middleware.
        /// </summary>
        /// <typeparam name="THealthService"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomGRpcHealthChecks<THealthService>(this IServiceCollection services) where THealthService : BackgroundService
        {
            services.AddSingleton<HealthServiceImpl>();
            services.AddHostedService<THealthService>();//GRpcStatusService
            return services;
        }

        /// <summary>
        /// Health Checks with DbContext support for Sooduskorv custom middleware.
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomHealthChecks<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddHealthChecks().AddDbContextCheck<TDbContext>();
            /*services.AddHealthChecksUI().AddInMemoryStorage();*/
            return services;
        }

        /// <summary>
        /// Health Checks with DbContext and UrlGroup support for Sooduskorv custom middleware.
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomUrlHealthChecks<TDbContext>(this IServiceCollection services, IConfiguration config) where TDbContext : DbContext
        {
            services.AddHealthChecks().AddDbContextCheck<TDbContext>()// TODO replace URI with IConfiguration
                .AddUrlGroup(new Uri("https://catalog.api:12345", UriKind.Absolute), HealthService.Catalog,
                    HealthStatus.Degraded, timeout: TimeSpan.FromSeconds(2));
            /*services.AddHealthChecksUI().AddInMemoryStorage();*/
            return services;
        }

        /// <summary>
        /// Event Bus Health Checks without DbContext support for Sooduskorv custom middleware.
        /// Chain into services.AddHealthChecks()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="config"></param>
        /// <param name="topic"></param>
        /// <param name="connectionString"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IHealthChecksBuilder AddCustomBusHealthChecks(this IHealthChecksBuilder builder, IConfiguration config,
            string topic, string connectionString, HealthStatus s = HealthStatus.Unhealthy)
        {
            return builder;
        }

        // TODO Add .AddPrometheusGatewayPublisher(); into chaining later.
        // TODO Configure the application pipeline here; app.UseHealthChecksPrometheusExporter();
        // TODO config.MapHealthChecksUI(setup => for the interactive UI.
    }
}