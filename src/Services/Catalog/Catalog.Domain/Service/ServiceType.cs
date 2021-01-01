using Catalog.Data.Product;
using Catalog.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Service
{
    public sealed class ServiceType : BaseProductType
    {

        public ServiceType(ProductTypeData d = null) : base(d) { }

       

    }
}
