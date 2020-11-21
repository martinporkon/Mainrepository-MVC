using Sooduskorv_MVC.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog.Facade.Product
{
    public sealed class ProductCategoryView:PeriodView
    {
        [DisplayName("Base category")]
        public string BaseCategoryId { get; set; }
    }
}
