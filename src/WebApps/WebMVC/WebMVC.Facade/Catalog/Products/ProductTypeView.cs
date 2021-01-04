using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Web.Domain.Common.Catalog.Products;
using Web.Domain.Services.Catalog.Products.ProductTypes;
using Web.Facade.Common;

namespace Web.Facade.Profiles.Catalog.Products
{
    public class ProductTypeView : DefinedView
    {
        [DisplayName("Product Type")]
        public ProductKind ProductKind { get; set; }

        [DisplayName("Pricing Strategy")]
        public PricingStrategy PricingStrategy { get; set; }

        public double Amount { get; set; }

        [DisplayName("Unit")]
        public string UnitId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Period Of Operation From")]
        public DateTime? PeriodOfOperationFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Period Of Operation To")]
        public DateTime? PeriodOfOperationTo { get; set; }

        [DisplayName("Numeric Code")]
        public int NumericCode { get; set; }

        [DisplayName("BaseType")]
        public string BaseTypeId { get; set; }

        public string Columns { get; set; }

        public string Rows { get; set; }

        public string Levels { get; set; }
    }
}