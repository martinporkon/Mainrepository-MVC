using System.Text;
using EventBus.Abstractions;
using EventBus.Common;
using EventBus.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventBusRabbitMQ.EventBus
{
    public class EventBusRabbitMq : IEventBus
    {
        public IConnectionFactory ConnectionFactory;
        public EventBusRabbitMq(IServiceScopeFactory ssf, IConfiguration configuration)
        {
            ConnectionFactory = new ConnectionFactory { HostName = "localhost", UserName = "", Password = "s", Port = 5672 };
            var baz = ssf.CreateScope();
            /*var foo = baz.ServiceProvider.GetService();*/
        }
        public void Publish(IntegrationEvent @event, string topic)
        {
            using (var connection = ConnectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "", type: ExchangeType.Topic);

                var json = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(
                    exchange: "",
                    "",
                    body: body);
            }
        }

        public void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeDynamic<TH>(string eventName, string topicName) where TH : IDynamicIntegrationEventHandler
        {
            throw new System.NotImplementedException();
        }

        public void UnsubscribeDynamic<TH>(string eventName, string topicName) where TH : IDynamicIntegrationEventHandler
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}