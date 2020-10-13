using System;
using System.IO;
using Basket.Infra;
using Catalog.Infra;
using Identity.Infra.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order.Infra;

namespace SooduskorvWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbCatalog = services.GetRequiredService<CatalogDbContext>();
                    CatalogDbInitializer.Initialize(dbCatalog);
                    var dbBasket = services.GetRequiredService<BasketDbContext>();
                    BasketDbInitializer.Initialize(dbBasket);
                    var dbOrder = services.GetRequiredService<OrderDbContext>();
                    OrderDbInitializer.Initialize(dbOrder);
                    var dbAddress = services.GetRequiredService<AddressDbContext>();
                    AddressDbInitializer.Initialize(dbAddress);
                    var dbShipping = services.GetRequiredService<ShippingDbContext>();
                    ShippingDbInitializer.Initialize(dbShipping);

                }
                catch (Exception ex)
                {
                   
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
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