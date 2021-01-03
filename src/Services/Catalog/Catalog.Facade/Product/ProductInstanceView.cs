using Catalog.Data.Product;
using Catalog.Data.Services;
using Sooduskorv_MVC.Facade;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Facade.Product
{
    public sealed class ProductInstanceView:PeriodView
    {
        [DisplayName("Product Type")]
        public string ProductTypeId { get; set; }
        [DisplayName("Product Kind")]

        public ProductKind ProductKind { get; set; }

        public double Amount { get; set; }

        [DisplayName("Unit")]
        public string UnitId { get; set; }

        [DisplayName("Party")]
        public string PartyId { get; set; }

        [DisplayName("Scheduled from")]
        [DataType(DataType.Date)]
        public DateTime ScheduledFrom { get; set; }

        [DisplayName("Scheduled to")]
        [DataType(DataType.Date)]
        public DateTime ScheduledTo { get; set; }

        [DisplayName("Delivered from")]
        [DataType(DataType.Date)]
        public DateTime DeliveredFrom { get; set; }

        [DisplayName("Delivered to")]
        [DataType(DataType.Date)]
        public DateTime DeliveredTo { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }
       
    }
}
