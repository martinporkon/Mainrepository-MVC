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
            _messageBus = messageBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            stoppingToken.Register(() =>
            {

            });


            throw new NotImplementedException();
        }
    }
}