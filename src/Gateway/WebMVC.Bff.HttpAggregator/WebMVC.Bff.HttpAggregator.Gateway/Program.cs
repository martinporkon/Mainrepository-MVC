using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebMVC.Bff.HttpAggregator.Gateway
{
    public class Program
    {
        /// <summary>
        /// TODO: Refactor later.
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5412")
                .CreateLogger();

            //ThreadPool.SetMaxThreads(12345, Environment.ProcessorCount);

            await CreateHost(args);// TODO test if working.

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

        private async Task<bool> InitDatabase()
        {
            /*if (Exception vms....)
            {
                /*var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
                    using (var scope = scopeFactory.CreateScope())
                    {
                         var db = scope.ServiceProvider.GetRequiredService<BffDbContext>();
                         if (db.Database.EnsureCreated())
                             {
                           //initializer
                        }
                    }
                return false;
            }*/
            return true;
        }

        private static async Task CreateHost(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).ConfigureAppConfiguration((hostContext, builder) =>
                {
                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddUserSecrets<Program>();
                    }
                }).Build();

                /*await InitDatabase();*/

                Log.Information($"The Gateway Application is starting up: {DateTime.UtcNow}");
                await host.RunAsync();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Fatal");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}