using Catalog.Data.ProductFeature;
using Catalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.ProductFeature
{
    //public abstract class FeatureValue<TData> : UniqueEntity<TData> where TData : FeatureValueData, new()
    //{

    //    protected FeatureValue(TData d = null) : base(d) { }

    //    public IValue Value => ValueFactory.Create(Data?.Value);

    //    public string FeatureTypeId => Data?.FeatureTypeId ?? Unspecified;

    //    public FeatureType FeatureType => new GetFrom<IFeatureTypesRepository, FeatureType>().ById(FeatureTypeId);

    //}
}
