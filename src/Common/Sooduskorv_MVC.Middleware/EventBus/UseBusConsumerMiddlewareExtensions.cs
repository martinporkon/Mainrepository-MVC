using EventBusRabbitMQ.Main;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class UseBusConsumerMiddlewareExtensions
    {
        public static IBusConsumer BusConsumer { get; set; }
        /// <summary>
        /// Registers the consumer during server start.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBusConsumer<T>(this IApplicationBuilder app, IConfiguration configuration = null) where T : IBusConsumer
        {
            BusConsumer = app.ApplicationServices.GetService<T>();
            var application = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            application.ApplicationStarted.Register(BusConsumer.StartProcess);
            application.ApplicationStopping.Register(BusConsumer.EndProcess);
            return app;
        }
    }
}