using System;
using System.Threading;
using System.Threading.Tasks;
using EventBus.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Basket.API.Hosted
{
    public class MessageService : BackgroundService
    {
        public IEventBus _messageBus;
        public MessageService(IEventBus messageBus)
        {
            this._messageBus = messageBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            stoppingToken.Register(() =>
            {
                // log everything.
                // fire an event when the application is shutting down.
                // external event that we can subscribe to for automated alerting and metrics.
            });


            throw new NotImplementedException();
        }
    }
}