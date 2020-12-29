using System.Threading.Tasks;

namespace EventBus.Common
{
    public interface IDynamicIntegrationEventHandler
    {
        Task HandleAsync(dynamic eventData);
    }
}