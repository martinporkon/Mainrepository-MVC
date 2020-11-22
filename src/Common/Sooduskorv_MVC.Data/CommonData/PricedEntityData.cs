namespace Sooduskorv_MVC.Data.CommonData
{
    public abstract class PricedEntityData : PeriodData
    {
        public decimal Price { get; set; }
    }
}