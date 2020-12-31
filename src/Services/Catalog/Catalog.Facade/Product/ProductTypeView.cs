using Catalog.Data.Product;
using Sooduskorv_MVC.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog.Facade.Product
{
    public sealed class ProductTypeView : DescribedEntityView
    {
        public ProductKind ProductKind { get; set; }
        public double Amount { get; set; }
        [DisplayName("Unit")]
        public string UnitId { get; set; }
        [DisplayName("Brand")]
        public string BrandId { get; set; }
        [DisplayName("Country of origin")]
        public string CountryOfOriginId { get; set; }
        public string BarCode { get; set; }
        public string Image { get; set; }
        public List<PartyInstanceView> parties { get; set; } = new List<PartyInstanceView> { new PartyInstanceView() };

        public int ProductsInUserBasket
        {
            get;// TODO -1
            set;// TODO -1
        } = 0;


    }
}
