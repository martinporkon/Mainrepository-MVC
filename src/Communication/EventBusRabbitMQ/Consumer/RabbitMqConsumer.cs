using System;
using EventBus.Abstractions;

namespace EventBusRabbitMQ.Main
{
    public class RabbitMqConsumer : IRabbitMqConsumer
    {
        private readonly IEventBus _messageBus;

        public RabbitMqConsumer(IEventBus messageBus)
        {
            _messageBus = messageBus;// TODO
        }

        public void EndProcess()
        {
            throw new NotImplementedException();
        }

        public void StartProcess()
        {
            throw new NotImplementedException();
        }
    }
}