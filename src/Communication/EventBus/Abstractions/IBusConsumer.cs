namespace EventBusRabbitMQ.Main
{
    public interface IBusConsumer
    {
        void EndProcess();
        void StartProcess();
    }
}