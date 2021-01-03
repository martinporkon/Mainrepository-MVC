using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.ProductFeature
{
    public abstract class FeatureValueData:UniqueEntityData
    {
        public string FeatureTypeId { get; set; }
        public ValueData Value { get; set; }
    }
}
