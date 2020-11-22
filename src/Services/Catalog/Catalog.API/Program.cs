using System;
using System.IO;
using Catalog.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Catalog.API
{
    public class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
            .Build();


        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            var host = CreateHostBuilder(args).ConfigureAppConfiguration((hostContext, builder) =>
            {
                if (hostContext.HostingEnvironment.IsDevelopment())
                {
                    builder.AddUserSecrets<Program>();
                }
            }).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbCatalog = services.GetRequiredService<CatalogDbContext>();
                    CatalogDbInitializer.Initialize(dbCatalog);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                    throw new Exception("initializer ei läinud läbi");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(GetConfiguration());
                });

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
