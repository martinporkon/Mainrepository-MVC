/*using Microsoft.AspNetCore.Hosting;
using Serilog;

[assembly: HostingStartup(typeof(WebMVC.Bff.HttpAggregator.Gateway.Configuration.LoggingStartup))]
namespace WebMVC.Bff.HttpAggregator.Gateway.Configuration
{
    public class LoggingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureLogging((context, builder) =>
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Seq("http://localhost:5412")
                    .CreateLogger();
            }).ConfigureServices((context, services) => { });
        }
    }
}*/// TODO fails to execute.