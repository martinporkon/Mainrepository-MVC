using CommonData;
using Sooduskorv_MVC.Data.CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Product
{
    public sealed class ProductTypeData : DescribedEntityData
    {
        public ProductKind ProductKind { get; set; }
        public double Amount { get; set; }
        public string UnitId { get; set; }
        public DateTime? PeriodOfOperationFrom { get; set; }
        public DateTime? PeriodOfOperationTo { get; set; }
        public string BrandId { get; set; }
        public string CountryOfOriginId { get; set; }
        public string BarCode { get; set; }
        public string Image { get; set; }

    }
}
