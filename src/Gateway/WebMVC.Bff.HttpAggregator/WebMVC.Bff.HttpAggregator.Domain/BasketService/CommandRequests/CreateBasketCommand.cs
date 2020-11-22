using MediatR;

namespace WebMVC.HttpAggregator.Infra.BasketService.Commands
{
    public class CreateBasketCommand : IRequest<object>
    {
        public string UserId { get; set; }
        public string BasketId { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }

        // veel properteid vms
    }
}