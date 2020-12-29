using Basket.Domain.Common;

namespace Basket.Domain.Baskets
{
    public interface IBasketItem : IUniqueEntity<BasketItemData> { }
    public class BasketItemData
    {
        public string Id { get; set; }
    }
}