using EventBusRabbitMQ.Main;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    public static class UseBusPublisherMiddlewareExtensions
    {
        /// <summary>
        /// Registers the publisher during server start.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBusPublisher<T>(this IApplicationBuilder app, IConfiguration configuration) where T : IBusConsumer
        {
            return app;
        }
    }
}