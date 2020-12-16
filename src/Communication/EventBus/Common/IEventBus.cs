using System;
using EventBus.Common;
using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IEventBus : IDisposable
    {
        void Publish(IntegrationEvent @event, string topic);

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void SubscribeDynamic<TH>(string eventName, string topic)
            where TH : IDynamicIntegrationEventHandler;

        void UnsubscribeDynamic<TH>(string eventName, string topic)
            where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}