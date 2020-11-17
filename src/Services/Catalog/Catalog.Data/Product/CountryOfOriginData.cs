using CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Product
{
    public sealed class CountryOfOriginData:DescribedEntityData
    {
        public string OfficialName { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public bool IsIsoCOuntry { get; set; }

    }
}
