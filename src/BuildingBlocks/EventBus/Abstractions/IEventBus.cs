using System;
using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IEventBus : IDisposable
    {
        void Publish(IntegrationEvent @event, string topic);
    }
}