using MediatR;

namespace WebMVC.Bff.HttpAggregator.Domain.BasketService.CommandRequests
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