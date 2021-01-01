using CommonData;
using Sooduskorv_MVC.Data.CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.ProductFeature
{
    public abstract class FeatureValueData:UniqueEntityData
    {
        public string FeatureTypeId { get; set; }
        public ValueData Value { get; set; }
    }
}
