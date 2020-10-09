namespace Order.Data.Common
{
    public abstract class PricedEntityData : PeriodData
    {
        public decimal Price { get; set; }
    }
}