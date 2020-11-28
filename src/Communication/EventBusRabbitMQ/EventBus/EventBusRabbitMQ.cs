using System.Text;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventBusRabbitMQ.EventBus
{
    public class EventBusRabbitMQ : IEventBus
    {
        public IConnectionFactory ConnectionFactory;
        public EventBusRabbitMQ(IConfiguration configuration)
        {
            ConnectionFactory = new ConnectionFactory { HostName = "localhost", UserName = "", Password = "s", Port = 5672 };
        }
        public void Publish(IntegrationEvent @event, string topic)
        {
            using (var connection = ConnectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "", type: ExchangeType.Fanout);

                string json;
                json = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(
                    exchange: "",
                    "",
                    body: body);
            }
        }

        public void Dispose()
        {
        }
    }
}