using Catalog.Data.Services;
using CommonData;
using Sooduskorv_MVC.Data.CommonData;
using System;

namespace Catalog.Data.Product
{
    public sealed class ProductInstanceData : PeriodData
    {
        public string ProductTypeId { get; set; }

        public double Amount { get; set; }
        public string UnitId { get; set; }

        public DateTime ScheduledFrom { get; set; }
        public DateTime ScheduledTo { get; set; }
        public DateTime DeliveredFrom { get; set; }
        public DateTime DeliveredTo { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
    }
}