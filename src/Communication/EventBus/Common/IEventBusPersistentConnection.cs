using System;
using RabbitMQ.Client;

namespace EventBus.Common
{
    public interface IEventBusPersistentConnection : IDisposable
    {
        bool IsConnected { get; }

        IModel CreateModel();

        bool TryConnect();
    }
}