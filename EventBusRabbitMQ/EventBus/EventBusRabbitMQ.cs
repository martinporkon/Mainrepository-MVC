using System;
using EventBus.Abstractions;
using EventBus.Events;

namespace EventBusRabbitMQ.EventBus
{
    public class EventBusRabbitMQ : IEventBus
    {
        public EventBusRabbitMQ()
        {

        }
        public void Publish(IntegrationEvent @event, string topic)
        {
            throw new NotImplementedException();
        }
    }
}