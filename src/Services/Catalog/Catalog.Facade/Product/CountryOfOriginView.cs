using Sooduskorv_MVC.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog.Facade.Product
{
    class CountryOfOriginView:PeriodView
    {
        [DisplayName("Official name")]
        public string OfficialName { get; set; }
        [DisplayName("Native name")]
        public string NativeName { get; set; }
        [DisplayName("Numeric code")]
        public string NumericCode { get; set; }
        public bool IsIsoCOuntry { get; set; }

    }
}
